using System;
using AudioToolbox;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Linq;

namespace Xamarin.Examples.Demo.iOS
{
    public class AudioRecorder
    {
        public short[] samples;

        private const int BitsPerSample = 16;
        private const int ChannelCount = 1;
        private const int CountAudioBuffers = 3;
        private const int BufferSize = 2048;

        private InputAudioQueue audioQueue;
        private int SampleRate;

        private bool Active => audioQueue?.IsRunning ?? false;

        public AudioRecorder(int sampleRate)
        {
            SampleRate = sampleRate;
            samples = new short[sampleRate];
        }

        void BufferOperation(Func<AudioQueueStatus> bufferFn, Action successAction = null, Action<AudioQueueStatus> failAction = null)
        {
            var status = bufferFn();

            if (status == AudioQueueStatus.Ok)
            {
                successAction?.Invoke();
            }
            else
            {
                if (failAction != null)
                {
                    failAction(status);
                }
                else
                {
                    throw new Exception($"AudioStream buffer error :: buffer operation returned non - Ok status:: {status}");
                }
            }
        }

        public Task Start()
        {
            try
            {
                if (!Active)
                {
                    InitAudioQueue();
                    audioQueue.Start();
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AudioStream.Start(): {0}", ex.Message);

                Stop();
                throw;
            }
        }

        public Task Stop()
        {
            if (audioQueue != null)
            {
                audioQueue.InputCompleted -= QueueInputCompleted;

                if (audioQueue.IsRunning)
                {
                    audioQueue.Stop(true);
                }
                audioQueue.Dispose();
                audioQueue = null;
            }
            return Task.FromResult(true);
        }

        void InitAudioQueue()
        {
            var bytes = (BitsPerSample / 8);
            var audioFormat = new AudioStreamBasicDescription
            {
                SampleRate = SampleRate,
                Format = AudioFormatType.LinearPCM,
                FormatFlags = AudioFormatFlags.LinearPCMIsSignedInteger | AudioFormatFlags.LinearPCMIsPacked,
                FramesPerPacket = ChannelCount,
                ChannelsPerFrame = ChannelCount,
                BitsPerChannel = BitsPerSample,
                BytesPerPacket = bytes,
                BytesPerFrame = bytes,
                Reserved = 0
            };

            audioQueue = new InputAudioQueue(audioFormat);
            audioQueue.InputCompleted += QueueInputCompleted;

            var bufferByteSize = BufferSize * audioFormat.BytesPerPacket;

            for (var index = 0; index < CountAudioBuffers; index++)
            {
                audioQueue.AllocateBufferWithPacketDescriptors(bufferByteSize, BufferSize, out IntPtr bufferPtr);
                audioQueue.EnqueueBuffer(bufferPtr, bufferByteSize, null);
            }
        }

        void QueueInputCompleted(object sender, InputCompletedEventArgs e)
        {
            try
            {
                if (!Active)
                {
                    return;
                }

                if (e.Buffer.AudioDataByteSize > 0)
                {
                    var audioBytes = new byte[e.Buffer.AudioDataByteSize];
                    Marshal.Copy(e.Buffer.AudioData, audioBytes, 0, (int)e.Buffer.AudioDataByteSize);

                    var size = audioBytes.Count() / sizeof(short);
                    for (var index = 0; index < size; index++)
                    {
                        samples[index] = BitConverter.ToInt16(audioBytes, index * sizeof(short));
                    }

                    // check if active again, because the auto stop logic may stop the audio queue from within this handler!
                    if (Active)
                    {
                        BufferOperation(() => audioQueue.EnqueueBuffer(e.IntPtrBuffer, null), null, status =>
                        {
                            Console.WriteLine("AudioStream.QueueInputCompleted() :: audioQueue.EnqueueBuffer returned non-Ok status :: {0}", status);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("AudioStream.QueueInputCompleted() :: Error: {0}", ex.Message);
            }
        }
    }
}

