using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EtykietyAdresowe.Controler
{
   public static class outputController
    {
        public static void fillInterface(Form1 form)
        {
            using (var reader = new StreamReader("file.txt"))
            {
                var controls = form.Controls.OfType<TextBox>().ToList();
                List<TextBox> usedTextboxList = new List<TextBox>();
                for (int i = 3; i < 7; i++) {
                    usedTextboxList.Add(controls.Where(x => x.Name.Equals($"textBox{i}")).FirstOrDefault());
                }

                foreach(var box in usedTextboxList)
                {
                    box.Text = "udalo sie";
                }
            }

        }

    }
}
