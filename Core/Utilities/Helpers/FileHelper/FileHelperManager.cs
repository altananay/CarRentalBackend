using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath)) //Client'dan gelen dosyanın adresi daha önce var mı ?
            {
                File.Delete(filePath); //Dosya bulunduğu yerden siliniyor
            }
            return Upload(file, root); //Upload fonksiyonuna parametreler yollanarak dosya upload edilcek
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //dosya client'dan geldi mi gelmedi mi ?
            {
                //Gönderilen dosyanın path'i var mı ? Varsa if'in içine girmez
                if (!Directory.Exists(root))
                {
                    //Dosyanın path'i yoksa path'i oluştur.
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //dosyanın uzantısını al. .png, .jpeg, vb
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string filePath = guid + extension; //dosyanın unique ismi + uzantısı

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream); //Client'dan gelen dosya nereye kopyalanacak ?
                    fileStream.Flush(); //önbellekten silme
                    return filePath; //dosyanın tam adını return et
                }
            }
            return null;
        }
    }
}