using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtykietyAdresowe.Controler
{
    class dataController
    {

        string NIP;
        string PESEL;

        public dataController(string nip, string pesel)
        {
            NIP = nip;
            PESEL = pesel;
        }

        public void makeSql()
        {
            string query = String.Empty;
            if (!string.IsNullOrEmpty(NIP))
            {
               query = $@"set heading off
set pause off
set feedback off
set verify off
spool C:\\ETYKIETY\etykieta.txt
select nazwisko || ' ' || imie1 || CHR(13) || CHR(10) || CHR(13) || CHR(10) || ulica || ' ' || nr_domu || '/' || nr_mieszkania || CHR(13) || CHR(10) || kod_pocztowy || ' ' || miejscowosc from podmioty where nip = '{this.NIP}';
spool off
exit";
            }
            else
            {
                query = $@"set heading off \n set pause off \n set feedback off \n set verify off \n 
            spool C:\\ETYKIETY\etykieta.txt \n 
            select nazwisko || ' ' || imie1 || CHR(13) || CHR(10) || CHR(13) || CHR(10) || ulica || ' ' || nr_domu || '/' || nr_mieszkania || CHR(13) || CHR(10) || kod_pocztowy || ' ' || miejscowosc
            from podmioty where pesel = \'{this.PESEL}\'; \n spool off \n exit";
            }

            using (var fileStream = new FileStream(String.Format($"tempFile.sql"), FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(query);
                }
            }
           
        }

        public void deleteSql()
        {
            File.Delete("tempFile.sql");
        }

       

    }
}
