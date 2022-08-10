using System.Windows.Forms;
using DataGen.Data;
using DataGen.Ui;

namespace DataGen.Start
{
    class DgLauncher
    {
        public static Form Start()
        {
            var settings = DgSettings.Default;
            var progress = new MyProgress(settings);

            var dao = new GenDao(settings.ConnectionString);
            
            var maxMySourceId = dao.GetMaxMySourceId();
            var maxCommentId = dao.GetMaxCommentId();

            var g = new Generator(dao, maxMySourceId ?? 0, maxCommentId ?? 0, progress, settings);

            return new DataGenForm(g, progress, settings);
        }

    }
}
