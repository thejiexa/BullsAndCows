namespace BullsAndCows
{
    public partial class MainForm : Form
    {
        Game? player1;
        Game? player2;

        public MainForm()
        {
            InitializeComponent();
            DropControls();
            textBox2.ScrollBars = textBox1.ScrollBars = ScrollBars.Vertical;
            Icon = Icon.ExtractAssociatedIcon(@"../../../images/icon.ico");
            pveRb.BackgroundImage = Image.FromFile(@"../../../images/pve.png");
            pvpRb.BackgroundImage = Image.FromFile(@"../../../images/pvp.png");
        }

        private void MakeMove(ref Game player, ref Game opponent, string inputNumber = "", bool isTheOpponentAI = false)
        {
            bool isInputNumberAlreadyUser = player is Game.Player && player.IsTheNumberAlreadyUsed(inputNumber);
            bool isInputNumberCorrect;
            string message;
            (isInputNumberCorrect, message) = Game.IsTheNumberCorrect(inputNumber);

            switch (player, opponent, isTheOpponentAI, isInputNumberCorrect, isInputNumberAlreadyUser)
            {
                case (_, _, _, false, _):
                    BackColor = Color.Crimson;
                    MessageBox.Show(message);
                    BackColor = Color.LightPink;
                    return;
                case (_, _, _, _, true):
                    BackColor = Color.Crimson;
                    MessageBox.Show($"{inputNumber} already used");
                    BackColor = Color.LightPink;
                    return;
                case (Game.Player, Game.AI, _, _, _):
                    player.Move(opponent, inputNumber);
                    opponent.Move(player);
                    break;
                case (Game.Player, Game.Player, _, _, _):
                    player.Move(opponent, inputNumber);
                    break;
                case (null, null, true, _, _):
                    StartNewGame(ref player, inputNumber);
                    StartNewGame(ref opponent);
                    break;
                case (null, _, false, _, _):
                    StartNewGame(ref player, inputNumber);
                    break;

            };

            switch (player2?.GetHashCode() == player?.GetHashCode(), opponent)
            {
                case (_, Game.AI):
                    UpdateControls(player, listBox1, textBox1, button1);
                    UpdateControls(opponent, listBox2, textBox2, button2);
                    WinnerCheck();
                    break;
                case (false, _):
                    UpdateControls(player, listBox1, textBox1, button1);
                    break;
                case (true, _):
                    UpdateControls(player, listBox2, textBox2, button2);
                    WinnerCheck();
                    break;
            };
        }

        private static void StartNewGame(ref Game player, string number = null)
        {
            player = (number) switch
            {
                null => new Game.AI(),
                _ => new Game.Player(number),
            };
        }

        void UpdateControls(Game game, ListBox listBox, TextBox textBox, Button button)
        {
            if (game is Game.Player)
                button.Text = "Guess the number";

            listBox.BackColor = game.Winner ? Color.PaleGreen : Color.Snow;
            textBox.Text = null;
            textBox.UseSystemPasswordChar = false;

            if (game?.MovesCount > 0)
            {
                listBox.Items.Insert(0, $"{game.MovesCount}:   {game.UsedNumbers?.Last()}     Bulls: {game.LastTryBullsCows.X}, Cows: {game.LastTryBullsCows.Y}");

                if (listBox.Height < textBox.Height * 12)
                    listBox.Height += textBox.Height;
            }

            if (cheatCb.Checked)
                cheatCb.Text = $"{player1?.TheNumber}\n{player2?.TheNumber}";

            if (player2 is not Game.AI)
            {
                button1.Enabled = !button1.Enabled;
                button2.Enabled = !button2.Enabled;
                textBox1.Enabled = !textBox1.Enabled;
                textBox2.Enabled = !textBox2.Enabled;
                textBox1.Select();
                textBox2.Select();
            }
        }

        void DropControls()
        {
            player1 = null;
            player2 = null;
            textBox1.Text = textBox2.Text = null;
            textBox1.UseSystemPasswordChar = pvpRb.Checked;
            textBox2.UseSystemPasswordChar = true;
            textBox1.Select();            
            listBox1.BackColor = listBox2.BackColor = Color.Snow;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Height = listBox2.Height = textBox1.Height;
            button1.Text = "Set a number";
            button2.Text = pveRb.Checked ? "Player 2 is AI" : "Set a number";
            button2.Enabled = textBox2.Enabled = false;
            button1.Enabled = textBox1.Enabled = true;
            cheatCb.Checked = false;
            cheatCb.Text = null;
        }

        void WinnerCheck()
        {
            string? message = (player1.Winner, player2.Winner) switch
            {
                (true, true) => "Draw",
                (true, false) => $"Player 1 won for {player1.MovesCount} moves",
                (false, true) => $"Player 2 won for {player2.MovesCount} moves",
                _ => null
            };

            if (message is null)
                return;

            MessageBox.Show(message);

            DropControls();
        }

        private void Button1_Click(object sender, EventArgs e) => MakeMove(ref player1, ref player2, textBox1.Text, pveRb.Checked);
        private void Button2_Click(object sender, EventArgs e) => MakeMove(ref player2, ref player1, textBox2.Text, pveRb.Checked);
        private void RadioButton_CheckedChanged(object sender, EventArgs e) => DropControls();
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        private void CheatCb_CheckedChanged(object sender, EventArgs e) => cheatCb.Text = cheatCb.Checked ? $"{player1?.TheNumber}\n{player2?.TheNumber}" : null;
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Button1_Click(this, new EventArgs());
        }
        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                button2.PerformClick();
        }
    }
}