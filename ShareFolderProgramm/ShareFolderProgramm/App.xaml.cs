using System.Windows;
using ShareFolderProgramm.View;
using SharedFolderProgrammDll.Model;

using SharedFolderProgrammDll.Algorythms.Creating;
using SharedFolderProgrammDll.Algorythms.Naming;
using SharedFolderProgrammDll.Algorythms.Sharing;
using SharedFolderProgrammDll.Algorythms.Feeding;
using ShareFolderProgramm.ViewModel;

namespace ShareFolderProgramm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ISharingFolderModel model = new SharingModel(new IncrementNameAlgorythm(), new CreateFolderAlgorythm(),
                new FeederAlgorythm(), new ShareFolderAndGiveFullAccessToEveryone());

            SharingFolderViewModel viewModel = new SharingFolderViewModel(model);

            MainWindow window = new MainWindow(viewModel);

            window.Show();
        }
    }
}
