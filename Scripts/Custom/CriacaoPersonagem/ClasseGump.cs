using Server.Gumps;
using Server.Network;

namespace Server.Custom
{
	public class ClasseGump : Gump
	{
		public ClasseGump() : base(50, 50)
		{
			this.AddBackground(0, 0, 400, 300, 5054);

			this.AddLabel(125, 10, 1152, "Escolha sua Classe:");

			int y = 70;
			int buttonID = 1;

			string[] classes = 
			{
				"Erudito",
				"Matador",
				"Caçador de Tesouros",
				"Andarilho",
				"Guardião",
				"Guerreiro"
			};

			foreach(string classe in classes)
			{
				this.AddButton(50, y, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
				this.AddLabel(80, y, 0, classe);
				y += 30;
				buttonID++;
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile m = sender.Mobile;
			int buttonID = info.ButtonID;
			// Lidar com a resposta
		}
	}
}