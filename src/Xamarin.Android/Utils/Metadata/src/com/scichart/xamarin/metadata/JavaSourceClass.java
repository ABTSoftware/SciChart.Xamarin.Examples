package com.scichart.xamarin.metadata;

import com.github.javaparser.JavaParser;
import com.github.javaparser.ParseException;
import com.github.javaparser.ast.CompilationUnit;
import com.github.javaparser.ast.Node;
import com.github.javaparser.ast.PackageDeclaration;
import com.github.javaparser.ast.body.*;
import com.github.javaparser.ast.expr.AnnotationExpr;
import com.github.javaparser.ast.visitor.VoidVisitorAdapter;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import static com.github.javaparser.ast.body.ModifierSet.*;

final class JavaSourceClass {
    private static final String CLASS_CONSTRUCTOR_FORMAT_STRING = "<attr path=\"/api/package[@name='%s']/class[@name='%s']/constructor[@name='%s' %s]/parameter[@name='p%d']\" name=\"name\">%s</attr>";

    private static final String CLASS_METHOD_FORMAT_STRING = "<attr path=\"/api/package[@name='%s']/class[@name='%s']/method[@name='%s' %s]/parameter[@name='p%d']\" name=\"name\">%s</attr>";
    private static final String INTERFACE_METHOD_FORMAT_STRING = "<attr path=\"/api/package[@name='%s']/interface[@name='%s']/method[@name='%s' %s]/parameter[@name='p%d']\" name=\"name\">%s</attr>";

    private static final String ENUM_VALUE_OF_FORMAT_STRING = "<attr path=\"/api/package[@name='%s']/class[@name='%s']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]/parameter[@name='p0']\" name=\"name\">name</attr>";
    private final List<String> attributesMetadata = new ArrayList<>();

    JavaSourceClass(File sourceFile) {
        CompilationUnit parsedSourceFile;
        try {
            parsedSourceFile = JavaParser.parse(sourceFile);
            if(parsedSourceFile != null) {
                final MethodVisitor methodVisitor = new MethodVisitor();
                methodVisitor.visit(parsedSourceFile, null);
            }
        } catch (ParseException | IOException e) {
            e.printStackTrace();
        }
    }

    List<String> getAttributeMetadata() {
        return attributesMetadata;
    }

    private class MethodVisitor extends VoidVisitorAdapter<Object>{
        private String packageName;
        private String typeName;
        private boolean isInterface;

        private boolean isPublicClassOrInterface;

        @Override
        public void visit(PackageDeclaration n, Object arg) {
            this.packageName = n.getPackageName();

            super.visit(n, arg);
        }

        @Override
        public void visit(ClassOrInterfaceDeclaration n, Object arg) {
            final String prevTypeName = typeName;
            final boolean prevIsInterface = isInterface;
            final boolean prevIsPublicClassOrInterface = isPublicClassOrInterface;

            this.typeName = getTypeName(n);
            this.isInterface = n.isInterface();
            this.isPublicClassOrInterface = isPublic(n.getModifiers()) || isProtected(n.getModifiers());

            super.visit(n, arg);

            this.typeName = prevTypeName;
            this.isInterface = prevIsInterface;
            this.isPublicClassOrInterface = prevIsPublicClassOrInterface;
        }

        private String getTypeName(TypeDeclaration node){
            final Node parentNode = node.getParentNode();
            if(parentNode instanceof TypeDeclaration){
                return getTypeName((TypeDeclaration) parentNode) + "." + node.getName();
            } else {
                return node.getName();
            }
        }

        @Override
        public void visit(ConstructorDeclaration n, Object arg) {
            super.visit(n, arg);

            if(!isPublicClassOrInterface || !isInterface || !(isPublic(n.getModifiers()) || isProtected(n.getModifiers()))) return;

            final String ctorName = typeName;
            final List<Parameter> parameters = n.getParameters();

            final int size = parameters.size();

            final List<String> parameterNames = new ArrayList<>(size);
            final String parameterConstrain = getParameterNamesAndParametersConstrain(parameters, parameterNames);

            for(int i = 0; i < size; i++){
                final String parameterName = parameterNames.get(i);
                final String attributeString = String.format(CLASS_CONSTRUCTOR_FORMAT_STRING, packageName, typeName, ctorName, parameterConstrain, i, parameterName);
                attributesMetadata.add(attributeString);
            }
        }

        @Override
        public void visit(MethodDeclaration n, Object arg) {
            super.visit(n, arg);

            if(!isPublicClassOrInterface || !isInterface || hasOverrideAnnotation(n)) {
                if (!isPublicClassOrInterface || !ModifierSet.isAbstract(n.getModifiers())) {
                    return;
                }
            }

            final boolean isValidInterfaceMethod = isInterface && (isPublic(n.getModifiers()) || isProtected(n.getModifiers()) || hasPackageLevelAccess(n.getModifiers()));
            final boolean isValidClassMethod = !isInterface && (isPublic(n.getModifiers()) || isProtected(n.getModifiers()));
            final boolean isNotEqualsMethod = !(isPublic(n.getModifiers()) && n.getName().equals("equals"));
            if(!(isValidInterfaceMethod || (isValidClassMethod && isNotEqualsMethod))) return;

            final String methodName = n.getName();
            final List<Parameter> parameters = n.getParameters();

            final int size = parameters.size();

            final List<String> parameterNames = new ArrayList<>(size);
            final String parameterConstrain = getParameterNamesAndParametersConstrain(parameters, parameterNames);

            final String formatString = isInterface ? INTERFACE_METHOD_FORMAT_STRING : CLASS_METHOD_FORMAT_STRING;

            for (int i = 0; i < size; i++) {
                final String parameterName = parameterNames.get(i);
                final String attributeString = String.format(formatString, packageName, typeName, methodName, parameterConstrain, i, parameterName);
                attributesMetadata.add(attributeString);
            }
        }

        private String getParameterNamesAndParametersConstrain(List<Parameter> parameters, List<String> parameterNames) {
            final int size = parameters.size();
            final StringBuilder parameterConstrainBuilder = new StringBuilder();

            parameterConstrainBuilder.append(String.format("and count(parameter)=%d ", size));
            for (int i = 0; i < size; i++) {
                final Parameter parameter = parameters.get(i);

                final String[] paramStrings = parameter.toString().split(" ");
                final String name = paramStrings[paramStrings.length - 1];
                final String type = paramStrings[paramStrings.length - 2];

                parameterNames.add(name);

                // if type contains '<' then it should be generic type
                final int genericIndex = type.indexOf('<');
                if(genericIndex != -1)
                    parameterConstrainBuilder.append(String.format("and parameter[%d][contains(@type, '%s')]",i + 1, type.substring(0, genericIndex)));
                else
                    parameterConstrainBuilder.append(String.format("and parameter[%d][substring(@type, string-length(@type) - string-length('%s') + 1) = '%s'] ", i + 1, type, type));
            }

            return parameterConstrainBuilder.toString();
        }

        private boolean hasOverrideAnnotation(MethodDeclaration methodDeclaration){
            boolean hasOverride = false;

            List<AnnotationExpr> annotations = methodDeclaration.getAnnotations();
            for (AnnotationExpr annotationExpr : annotations) {
                if (annotationExpr.getName().getName().contains("Override")) {
                    hasOverride = true;
                }
            }

            return hasOverride;
        }
    }
}