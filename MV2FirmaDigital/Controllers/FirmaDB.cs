using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using MV2FirmaDigital.Models;
using System.IO;

namespace MV2FirmaDigital.Controllers
{
    public class FirmaDB
    {
        readonly SQLiteAsyncConnection db;

        public FirmaDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<FirmaModel>().Wait();
        }

        public Task<List<FirmaModel>> GetFirmasList()
        {
            return db.Table<FirmaModel>().ToListAsync();
        }

        public Task<FirmaModel> GetFirmaID(int pcodigo)
        {
            return db.Table<FirmaModel>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GuadarFirma(FirmaModel firma)
        {
            if (firma.Id != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        public Task<int> EliminarFirma(FirmaModel firma)
        {
            return db.DeleteAsync(firma);
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
