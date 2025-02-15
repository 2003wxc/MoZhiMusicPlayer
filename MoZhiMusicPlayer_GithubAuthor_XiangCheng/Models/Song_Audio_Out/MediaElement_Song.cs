﻿using NAudio.Wave;
using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Libs.NAudio.Wave;
using VisioForge.MediaFramework.DSP.Equalizer;
using WaveOutEvent = NAudio.Wave.WaveOutEvent;
using WaveOut = NAudio.Wave.WaveOut;
using WaveFormat = NAudio.Wave.WaveFormat;
using ISampleProvider = NAudio.Wave.ISampleProvider;
using NAudio.Extras;
using NAudio.Wave;
using VisioForge.Libs.ZXing;
using Equalizer = NAudio.Extras.Equalizer;
using ViewModelBase = MoZhiMusicPlayer_GithubAuthor_XiangCheng.UserControlLibrary.MusicPlayer_Set.ViewModel.ViewModelBase;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using MoZhiMusicPlayer_GithubAuthor_XiangCheng.Services.Services_For_API_GetResult;

namespace MoZhiMusicPlayer_GithubAuthor_XiangCheng.Models.Song_Audio_Out
{
    public class MediaElement_Song : ViewModelBase
    {
        public WaveOutEvent waveOutEvent;
        private AudioFileReader audioFileReader;

        private Equalizer equalizer;
        private EqualizerBand[] bands;

        public event EventHandler MediaOpened; 
        public event EventHandler MediaEnded;

        public MediaElement_Song()
        {
            waveOutEvent = new WaveOutEvent();

            bands = new EqualizerBand[]
            {
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 31, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 62, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 125, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 250, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 500, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 1000, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 2000, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 4000, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 8000, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 16000, Gain = 0},
                new EqualizerBand {Bandwidth = 0.8f, Frequency = 20000, Gain = 0},
            };
            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            equalizer?.Update();
        }

        public RelayCommand RefCommand_Set_Equalizer { get; set; }

        /// <summary>
        /// 初始化播放
        /// </summary>
        /// <param name="audioFilePath"></param>
        public void Open(string audioFilePath)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                waveOutEvent.Dispose();
            }

            audioFileReader = new AudioFileReader(audioFilePath);

            if (bands != null && bands.Length > 0)
            {
                equalizer = new Equalizer(audioFileReader, bands);
                waveOutEvent = new WaveOutEvent();
                waveOutEvent.Init(equalizer);
            }
            else
            {
                waveOutEvent = new WaveOutEvent();
                waveOutEvent.Init(audioFileReader);
            }

            OnMediaOpened();
        }

        public void Play()
        {
            waveOutEvent.Play();
        }

        public void Pause()
        {
            waveOutEvent.Pause();
        }

        public void Stop()
        {
            waveOutEvent.Stop();
        }

        public TimeSpan CurrentTime
        {
            get { return audioFileReader?.CurrentTime ?? TimeSpan.Zero; }
            set
            {
                if (audioFileReader != null)
                {
                    audioFileReader.CurrentTime = value;
                }
            }
        }

        public TimeSpan TotalTime
        {
            get { return audioFileReader?.TotalTime ?? TimeSpan.Zero; }
        }

        public float Volume
        {
            get { return waveOutEvent?.Volume ?? 1.0f; }
            set
            {
                if (waveOutEvent != null)
                {
                    waveOutEvent.Volume = value;
                }
            }
        }

        public void SetOutputDevice(int deviceNumber)
        {
            if (WaveOut.DeviceCount > 0 && deviceNumber >= 0 && deviceNumber < WaveOut.DeviceCount)
            {
                waveOutEvent.DeviceNumber = deviceNumber;
            }
        }

        public void SetEqualizerBand(EqualizerBand[] temp)
        {
            if(temp != null)
                bands = temp;
        }

        private void OnMediaOpened()
        {
            MediaOpened?.Invoke(this, EventArgs.Empty);
        }




        public float MinimumGain => -12;
        public float MaximumGain => 12 ;

        /// <summary>
        /// 31
        /// </summary>
        public float Band1
        {
            get => bands[0].Gain;
            set
            {
                if (bands[0].Gain != value)
                {
                    bands[0].Gain = value;
                    OnPropertyChanged("Band1");
                }
            }
        }
        /// <summary>
        /// 62
        /// </summary>
        public float Band2
        {
            get => bands[1].Gain;
            set
            {
                if (bands[1].Gain != value)
                {
                    bands[1].Gain = value;
                    OnPropertyChanged("Band2");
                }
            }
        }
        /// <summary>
        /// 125
        /// </summary>
        public float Band3
        {
            get => bands[2].Gain;
            set
            {
                if (bands[2].Gain != value)
                {
                    bands[2].Gain = value;
                    OnPropertyChanged("Band3");
                }
            }
        }
        /// <summary>
        /// 250
        /// </summary>
        public float Band4
        {
            get => bands[3].Gain;
            set
            {
                if (bands[3].Gain != value)
                {
                    bands[3].Gain = value;
                    OnPropertyChanged("Band4");
                }
            }
        }
        /// <summary>
        /// 500
        /// </summary>
        public float Band5
        {
            get => bands[4].Gain;
            set
            {
                if (bands[4].Gain != value)
                {
                    bands[4].Gain = value;
                    OnPropertyChanged("Band5");
                }
            }
        }
        /// <summary>
        /// 1k
        /// </summary>
        public float Band6
        {
            get => bands[5].Gain;
            set
            {
                if (bands[5].Gain != value)
                {
                    bands[5].Gain = value;
                    OnPropertyChanged("Band6");
                }
            }
        }
        /// <summary>
        /// 2k
        /// </summary>
        public float Band7
        {
            get => bands[6].Gain;
            set
            {
                if (bands[6].Gain != value)
                {
                    bands[6].Gain = value;
                    OnPropertyChanged("Band7");
                }
            }
        }
        /// <summary>
        /// 4k
        /// </summary>
        public float Band8
        {
            get => bands[7].Gain;
            set
            {
                if (bands[7].Gain != value)
                {
                    bands[7].Gain = value;
                    OnPropertyChanged("Band7");
                }
            }
        }
        /// <summary>
        /// 8k
        /// </summary>
        public float Band9
        {
            get => bands[8].Gain;
            set
            {
                if (bands[8].Gain != value)
                {
                    bands[8].Gain = value;
                    OnPropertyChanged("Band8");
                }
            }
        }
        /// <summary>
        /// 16k
        /// </summary>
        public float Band10
        {
            get => bands[9].Gain;
            set
            {
                if (bands[9].Gain != value)
                {
                    bands[9].Gain = value;
                    OnPropertyChanged("Band9");
                }
            }
        }
        /// <summary>
        /// 20k
        /// </summary>
        public float Band11
        {
            get => bands[10].Gain;
            set
            {
                if (bands[10].Gain != value)
                {
                    bands[10].Gain = value;
                    OnPropertyChanged("Band7");
                }
            }
        }





        public static MediaElement_Song viewModule_MediaElement_Song { get; set; }
        public static MediaElement_Song Retuen_This()
        {
            viewModule_MediaElement_Song = Return_This_ViewModule_MediaElement_Song();
            return viewModule_MediaElement_Song;
        }
        private static MediaElement_Song Return_This_ViewModule_MediaElement_Song()
        {
            if (viewModule_MediaElement_Song == null)
                viewModule_MediaElement_Song = new MediaElement_Song();
            return viewModule_MediaElement_Song;
        }
    }
}
