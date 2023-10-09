using Server.Gumps;
using Server.Network;

namespace Server.Custom
{
	public class CriacaoPersonagemGump : Gump
	{
		public CriacaoPersonagemGump() : base(50, 50)
		{
			// Define o fundo da janela
			this.AddBackground(0, 0, 400, 500, 5054);

			// Título
			this.AddLabel(125, 10, 1152, "Criação de Personagem");

			// Escolha de Cultura
			this.AddLabel(50, 40, 1153, "Escolha sua Cultura:");

			int y = 70;
			int buttonID = 1;

			string[] culturas = 
			{
				"Bardos",
				"Beornings",
				"Dúnedain",
				"Anões da Montanha Solitária",
				"Elfos de Mirkwood",
				"Hobbits do Condado",
				"Homens de Bree",
				"Homens do Lago",
				"Homens de Minas Tirith",
				"Cavaleiros de Rohan",
				"Homens da Floresta Selvagem"
			};

			foreach(string cultura in culturas)
			{
				this.AddButton(50, y, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
				this.AddLabel(80, y, 0, cultura);
				y += 30;
				buttonID++;
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile m = sender.Mobile;
			int buttonID = info.ButtonID;

			// Aqui, você pode lidar com a resposta do jogador, talvez abrindo outro Gump 
			// para a próxima escolha (Classe, Background, Virtude) ou armazenando sua escolha
		}
	}
}