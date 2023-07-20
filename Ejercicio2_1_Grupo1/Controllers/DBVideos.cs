using Ejercicio2_1_Grupo1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace Ejercicio2_1_Grupo1.Controllers
{
    public class DBVideos 
    {
        readonly SQLiteAsyncConnection db;

        public DBVideos(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);

            db.CreateTableAsync<videos>().Wait();
        }

            /* Crear el CRUD de BD */

            // Create and update
            public Task<int> GuardarVideos(videos Videos)
            {
                if (Videos.id == 0)
                {
                    return db.InsertAsync(Videos);
                }
                else
                {
                    return db.UpdateAsync(Videos);
                }
            }

            // Read
            public Task<List<videos>> VerlistaVideos()
            {
                return db.Table<videos>().ToListAsync();
            }

            public Task<videos> ObtenerUnVideo(int id)
            {
                return db.Table<videos>()
                    .Where(i => i.id == id)
                    .FirstOrDefaultAsync();
            }

            // Delete 
            public Task<int> EliminaVideo(videos Videos)
            {
                return db.DeleteAsync(Videos);
            }

        }

    }
    
