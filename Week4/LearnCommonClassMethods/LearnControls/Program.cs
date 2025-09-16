namespace LearnControls
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form1 f = new Form1();
            f.Text = "Hello World";
            f.Size = new Size(800, 600);
            f.Opacity = 0.8;
            f.BackgroundImage = Image.FromFile("stack9.png");
            f.BackgroundImageLayout = ImageLayout.Stretch;

            // note, these are not 'design time' settings, until those lines are executed the properties do not change



            Application.Run(new frmCalculator());
        }
    }
}