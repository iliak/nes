using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NES
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			mem = new Memory();
			cpu = new MOS6502(mem);


			BankBox.SelectedIndex = 0;

			// Find available ROMs
			DirectoryInfo di = new DirectoryInfo("rom");
			ROMBox.Items.AddRange(di.EnumerateFiles("*.nes").ToArray());



			DynamicByteProvider dbp = new DynamicByteProvider(mem.RAM);
			hexBox1.ByteProvider = dbp;




			//LoadCartridge(cartridge);


			// http://msdn.microsoft.com/en-us/library/system.componentmodel.design.byteviewer.aspx
			//System.ComponentModel.Design.ByteViewer 

		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="cart"></param>
		/// <returns></returns>
		public bool LoadCartridge(string name)
		{
			Cartridge cart = new Cartridge(name);
			//cartridge.Load(@"D:\dev\mimicprod\emulator\NES\rom\nes-test-roms\PaddleTest3\paddletest.NES");
			//cart.Load(name);

			// Copy the first and the last PRGROM
			Array.Copy(cart.PRG, 0, mem.RAM, 0x8000, 0x4000);
			Array.Copy(cart.PRG, 0x4000 * (cart.PRGCount - 1), mem.RAM, 0xC000, 0x4000);


			// Build a dictionary with each offset position
			SourceList = new Dictionary<ushort, int>();
			string[] t = cpu.Disassemble().Split('\n');
			SourceCodeBox.Items.Clear();
			foreach (string s in t)
			{
				int index = SourceCodeBox.Items.Add(s);

				// No offset
				if (string.IsNullOrWhiteSpace(s))
					continue;

				ushort offset = Convert.ToUInt16(s.Substring(1, 4), 16);
				SourceList.Add(offset, index);
			}


			ROMInfoView.Items.Clear();
			ListViewItem item = new ListViewItem("Mapper ID");
			item.SubItems.Add("0x" + cart.Mapper.ToString("X2"));
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("Has Battery");
			item.SubItems.Add(cart.HasBattery.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("Has Trainer");
			item.SubItems.Add(cart.HasTrainer.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("CHR Count");
			item.SubItems.Add(cart.CHRCount.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("CHR Size");
			item.SubItems.Add((cart.CHRCount * 8).ToString() + " Ko");
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("PRG Count");
			item.SubItems.Add(cart.PRGCount.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("PRG Size");
			item.SubItems.Add((cart.PRGCount * 16).ToString() + " Ko");
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("Mirroring");
			item.SubItems.Add(cart.Mirroring.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("Video Mode");
			item.SubItems.Add(cart.VideoMode.ToString());
			ROMInfoView.Items.Add(item);

			item = new ListViewItem("Header Flags");
			item.SubItems.Add("0x" + cart.Flags.ToString("X8"));
			ROMInfoView.Items.Add(item);

			cpu.Reset();

			UpdateUI();

			return true;
		}


		/// <summary>
		/// 
		/// </summary>
		void UpdateUI()
		{
			if (cpu == null)
				return;

			UpdatingUI = true;

			// PC
			if (SourceList != null && SourceList.ContainsKey(cpu.PC))
				SourceCodeBox.SelectedIndex = SourceList[cpu.PC];

			// Flags
			FlagN.Checked = cpu.N;
			FlagV.Checked = cpu.V;
			FlagB.Checked = cpu.B;
			FlagD.Checked = cpu.D;
			FlagI.Checked = cpu.I;
			FlagZ.Checked = cpu.Z;
			FlagC.Checked = cpu.C;

			// Registers
			ABox.Text = cpu.A.ToString("X2");
			XBox.Text = cpu.X.ToString("X2");
			YBox.Text = cpu.Y.ToString("X2");
			PBox.Text = cpu.P.ToString("X2");
			PCBox.Text = cpu.PC.ToString("X4");
			PBox.Text = Convert.ToString(cpu.P, 2).PadLeft(8, '0');


			// Stack
			SPBox.Text = cpu.SP.ToString("X2");
			StackListBox.Items.Clear();
			for (ushort sp = 0xff; sp > cpu.SP; sp--)
			{
				byte val = mem.ReadByte(0x100 + sp);
				StackListBox.Items.Add("$" + val.ToString("X2"));
			}


			//hexBox1.ByteProvider.ApplyChanges();
			//hexBox1.ByteProvider.Bytes = mem.RAM;
			//hexBox1.

			StringBuilder sb = new StringBuilder();
			ushort start = (ushort)(BankBox.SelectedIndex * 0x1000);
			for (ushort pos = start; pos < start + 0x1000; pos += 0x10)
			{
				string line =
					pos.ToString("X4") + ":\t" +
					mem.RAM[pos + 0x0].ToString("X2") + " " +
					mem.RAM[pos + 0x1].ToString("X2") + " " +
					mem.RAM[pos + 0x2].ToString("X2") + " " +
					mem.RAM[pos + 0x3].ToString("X2") + " " +
					mem.RAM[pos + 0x4].ToString("X2") + " " +
					mem.RAM[pos + 0x5].ToString("X2") + " " +
					mem.RAM[pos + 0x6].ToString("X2") + " " +
					mem.RAM[pos + 0x7].ToString("X2") + " " +
					mem.RAM[pos + 0x8].ToString("X2") + " " +
					mem.RAM[pos + 0x9].ToString("X2") + " " +
					mem.RAM[pos + 0xA].ToString("X2") + " " +
					mem.RAM[pos + 0xB].ToString("X2") + " " +
					mem.RAM[pos + 0xC].ToString("X2") + " " +
					mem.RAM[pos + 0xD].ToString("X2") + " " +
					mem.RAM[pos + 0xE].ToString("X2") + " " +
					mem.RAM[pos + 0xF].ToString("X2") + "\t : ";

				//(char)mem.RAM[pos + 0x0] + " "
				;
				sb.AppendLine(line);
			}
			MemoryBox.Text = sb.ToString();

			UpdatingUI = false;
		}



		#region Properties

		/// <summary>
		/// Contains the position index of each PC position
		/// </summary>
		Dictionary<ushort, int> SourceList;

		/// <summary>
		/// 
		/// </summary>
		MOS6502 cpu;


		/// <summary>
		/// 
		/// </summary>
		Memory mem;


		/// <summary>
		/// True while updating UI
		/// </summary>
		bool UpdatingUI;

		#endregion


		#region UI events

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.F10)
			{
				if (cpu != null)
				{
					cpu.Step();
					UpdateUI();

					return true;
				}
			}

			else if (keyData == Keys.F11)
			{
				if (cpu != null)
				{
					Random rnd = new Random();
					for (byte i = 0; i < 0xff; i++)
						mem.WriteByte(i, (byte)rnd.Next());


					cpu.Step(true);
					UpdateUI();

					return true;
				}
			}


			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StepButton_Click(object sender, EventArgs e)
		{
			cpu.Step();
			UpdateUI();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StepOverButton_Click(object sender, EventArgs e)
		{
			if (cpu == null)
				return;

			Random rnd = new Random();
			for (byte i = 0; i < 0xff; i++)
				mem.WriteByte(i, (byte)rnd.Next());


			cpu.Step(true);
			UpdateUI();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;


			if (!SourceList.ContainsValue(SourceCodeBox.SelectedIndex))
			{
				return;
			}

			cpu.PC = SourceList.First(x => x.Value == SourceCodeBox.SelectedIndex).Key;


			UpdateUI();
		}

		private void ABox_TextChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.A = Convert.ToByte(ABox.Text, 16);
			//UpdateUI();
		}

		private void XBox_TextChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.X = Convert.ToByte(XBox.Text, 16);
			//UpdateUI();
		}

		private void YBox_TextChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.Y = Convert.ToByte(PBox.Text, 16);
			//UpdateUI();
		}

		private void FlagN_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.N = FlagN.Checked;
			UpdateUI();
		}

		private void FlagV_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.V = FlagV.Checked;
			UpdateUI();
		}

		private void FlagU_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			//cpu.U = FlagU.Checked;
			UpdateUI();
		}

		private void FlagB_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.B = FlagB.Checked;
			UpdateUI();
		}

		private void FlagD_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.D = FlagD.Checked;
			UpdateUI();
		}

		private void FlagI_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.I = FlagI.Checked;
			UpdateUI();
		}

		private void FlagZ_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.Z = FlagZ.Checked;
			UpdateUI();
		}

		private void FlagC_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatingUI)
				return;

			cpu.C = FlagC.Checked;
			UpdateUI();
		}

		private void ResetBox_Click(object sender, EventArgs e)
		{
			if (cpu == null)
				return;

			cpu.Reset();
			UpdateUI();
		}

		private void BankBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void hexBox1_Click(object sender, EventArgs e)
		{

		}

		private void ROMBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string name = ((ListBox)sender).Text;
			LoadCartridge("rom/" + name);
		}


		private void timer1_Tick(object sender, EventArgs e)
		{
			if (cpu == null)
				return;

			cpu.Step();
			UpdateUI();

		}

		#endregion

		private void StopButton_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			RunButton.Enabled = true;
			StopButton.Enabled = false;
			UpdateUI();
		}

		private void RunButton_Click(object sender, EventArgs e)
		{
			timer1.Start();
			StopButton.Enabled = true;
			RunButton.Enabled = false;
		}

	}
}
