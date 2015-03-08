//  
//  SDLAudio.cs
//  
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
// 
//  Copyright (c) 2009 - 2015 Ala Ibrahim Hadid
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Runtime.InteropServices;
using System.IO;
using MyNes.Core;
using SdlDotNet.Core;
using SdlDotNet.Audio;

namespace MyNesSDL
{
	public class SDLAudio : IAudioProvider
	{
		public SDLAudio ()
		{
			this.on = Settings.Audio_PlaybackEnabled;
			if (on) {
				try {
					Mixer.Initialize ();
					// TODO: find another way to adjust volume
					this.Volume = Settings.Audio_PlaybackVolume;

					callback = new AudioCallback (Signed16BigCallback);
					audio_stream = new AudioStream (Settings.Audio_PlaybackFrequency,
					                                AudioFormat.Signed16Big,
					                                SoundChannel.Mono, 2205, callback, "My Nes Sound");

					samples_buffer = new short[samples_count];

					Mixer.OpenAudio (audio_stream);
                   
					audio_stream.Paused = true;
					r_pos = w_pos = 0;
                    
				} catch (Exception ex) {
					Console.WriteLine (ex.ToString ());
				}
			}
			recorder = new WaveRecorder ();
		}

		private const int samples_count = 44100;
		private AudioStream audio_stream;
		private AudioCallback callback;
		private WaveRecorder recorder;
		private short[] samples_buffer;
		private short[] off_buffer;
		private int w_pos;
		private int r_pos;
		private double volume = 100;
		private double multi = 0;
		private bool isReading;
		private bool on;

		public double Volume {
			get{ return volume; }
			set {
				volume = value;
				multi = volume / 100.00;
			}
		}

		public bool Enabled {
			get  { return on; }
			set  { on = value; }
		}

		private  void Signed16BigCallback (IntPtr userData, IntPtr stream, int len)
		{
			if (on) {
				isReading = true;
				len /= 2;
				off_buffer = new short[len];
				for (int i = 0; i < len; i++) {
					off_buffer [i] = samples_buffer [r_pos];
					r_pos++;
					if (r_pos >= samples_count)
						r_pos = 0;
				}
				Marshal.Copy (off_buffer, 0, stream, len);

				if (r_pos > w_pos)// one block away ...
					r_pos = (w_pos / len) * len;
				isReading = false;
			}
		}

		public void AddSample (ref int sample)
		{
			if (!on)
				return;
			if (isReading)
				return;
			samples_buffer [w_pos] = (short)(multi * sample);
			w_pos++;
			if (w_pos >= samples_count)
				w_pos = 0;
		}

		public void SubmitBuffer (ref byte[] samples)
		{
		}

		public void Record ()
		{
			if (recorder.IsRecording)
				return;
			int j = 0;
			string path = "";
			string gameName = Path.GetFileNameWithoutExtension (Program.CurrentGameFile);
			path = Path.Combine (Settings.Folder_SoundRecords, gameName + "_" + j + ".wav");
			while (System.IO.File.Exists(path)) {
				j++;
				path = Path.Combine (Settings.Folder_SoundRecords, gameName + "_" + j + ".wav");
			}
			recorder.Record (path, 1, 16, Settings.Audio_PlaybackFrequency);
			Program.VIDEO.WriteNotification ("Recording started !!", 120, System.Drawing.Color.Lime);
		}

		public void StopRecord ()
		{
			if (recorder.IsRecording) {
				recorder.Stop ();
				Program.VIDEO.WriteNotification ("Recorded sound file saved !", 120, System.Drawing.Color.Lime);
			}
		}

		public void Play ()
		{
			if (!on)
				return;
			if (audio_stream != null) {
				if (audio_stream.Paused) {
					audio_stream.Paused = false;
					r_pos = w_pos = 0;
				}  
			}
		}

		public void Pause ()
		{ 
			if (audio_stream != null) {
				if (!audio_stream.Paused) {
					audio_stream.Paused = true;
					r_pos = w_pos = 0;
				}
			}
		}

		public void Shutdown ()
		{
			Pause ();
			// Noise on shutdown; MISC
			Random r = new Random ();
			for (int i = 0; i < samples_buffer.Length; i++)
				samples_buffer [i] = (short)r.Next (0, 40);
		}

		public void RecorderAddSample (ref int sample)
		{
			recorder.AddSample (ref sample);
		}

		public int CurrentWritePosition {
			get  { return 0; }
		}

		public bool IsPlaying {
			get {
				if (audio_stream != null)
					return !audio_stream.Paused;
				return false;
			}
		}

		public bool IsRecording {
			get {
				return recorder.IsRecording; 
			}
		}

		public int RecorderTime {
			get { return recorder.Time; }
		}
	}
}

