using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NES
{
	/// <summary>
	/// 
	/// </summary>
	public enum Mirroring
	{
		Horizontal,
		Vertical
	}

	public enum VideoMode
	{
		PAL,
		NTSC,
	}


	public class Cartridge
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public Cartridge(string filename)
		{
			using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				if (stream.Length < 16)
				{
					IsValid = false;
					return;
				}

				using (BinaryReader reader = new BinaryReader(stream))
				{
					// The header
					uint tmp32 = reader.ReadUInt32();
					if (tmp32 != magicHeader)
					{
						IsValid = false;
						return;
					}

					PRGCount = reader.ReadByte();
					CHRCount = reader.ReadByte();

					Flags = reader.ReadInt32();



					// Rewind and read dumps
					stream.Seek(16, SeekOrigin.Begin);

					PRG = new byte[PRGCount * 0x4000];
					stream.Read(PRG, 0, PRGCount * 0x4000);

					if (CHRCount > 0)
					{
						CHR = new byte[CHRCount * 0x2000];
						stream.Read(CHR, 0, CHRCount * 0x2000);
					}
					else
						CHR = new byte[0];

				}
			}
		}


		#region Properties

		/// <summary>
		/// Magic header => "NES\n"
		/// </summary>
		static uint magicHeader = 0x1a53454e;

		/// <summary>
		/// Whether this rom is valid or not.
		/// </summary>
		public bool IsValid { get; protected set; }


		/// <summary>
		/// Gets the PRG count.
		/// </summary>
		public int PRGCount { get; protected set; }


		/// <summary>
		/// Size of the PRG data
		/// </summary>
		public int PRGSize
		{
			get
			{
				return PRG.Length;
			}
		}

		/// <summary>
		/// Gets the CHR count.
		/// </summary>
		public int CHRCount { get; protected set; }

		/// <summary>
		/// Gets the PRG dump
		/// </summary>
		public byte[] PRG { get; protected set; }

		/// <summary>
		/// Gets the CHR dump
		/// </summary>
		public byte[] CHR { get; protected set; }

		/// <summary>
		/// ROM Header
		/// </summary>
		public int Flags { get; protected set; }


		#region Header properties


		/// <summary>
		/// Mapper ID
		/// </summary>
		public byte Mapper
		{
			get
			{
				return (byte)((Flags & 0xF000) >> 8 | ((Flags & 0x00F0) >> 4));
			}
		}


		/// <summary>
		/// Battery is present ?
		/// </summary>
		public bool HasBattery
		{
			get
			{
				return (Flags & 0x00000002) == 0x2;
			}
		}

		/// <summary>
		/// Trainer is present ?
		/// </summary>
		public bool HasTrainer
		{
			get
			{
				return (Flags & 0x00000004) == 0x4;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Mirroring Mirroring
		{
			get
			{
				return (Flags & 0x00000001) == 0x1 ? Mirroring.Vertical : Mirroring.Horizontal;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public VideoMode VideoMode
		{
			get
			{
				return (Flags & 0x01000000) == 0x01000000 ? VideoMode.PAL : VideoMode.NTSC;
			}
		}

		#endregion

		#endregion
	}
}
