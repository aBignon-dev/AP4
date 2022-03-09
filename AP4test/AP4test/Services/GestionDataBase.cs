using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using SQLiteNetExtensionsAsync.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AP4test.Config;
using AP4test.Models;

namespace Doctolibtest.Services
{
  public  class GestionDataBase
    {
        #region Attributs
        public  static SQLiteAsyncConnection Database => lazyInitializer.Value;
        
        public  static bool initialized = false;
        #endregion
        #region Constructeurs
        public GestionDataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConfig.DatabasePath, DatabaseConfig
                .Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                initialized = true;
            }
        }
        public Task MiseAJourItemRelation(object item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
        public ObservableCollection<T> GetItemsAsync<T>() where T : new()
        {
            ObservableCollection<T> resultat = new ObservableCollection<T>();
            List<T> liste = Database.Table<T>().ToListAsync().Result;
            foreach (T unObjet in liste)
            {
                resultat.Add(unObjet);
            }
            return resultat;
        }

        public Task<List<T>> GetItemsAsyncTodoItemEvent<T>() where T : new()
        {

            return Database.Table<T>().ToListAsync();
        }

        /* public Task<List<T>> GetItemsNotDoneAsync<T>() where T : new()
         {
             return Database.QueryAsync<T>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
         }
        */
        public Task<T> GetItemAsync<T>(int id) where T : new()
        {
            return Database.FindAsync<T>(id); ;
        }

        public Task<int> SaveItemAsync<T>(T item)
        {

            PropertyInfo x = (item.GetType().GetProperty("ID"));
            int nbi = Convert.ToInt32(x.GetValue(item));
            if (nbi != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync<T>(T item)
        {
            return Database.DeleteAsync(item);
        }
        public Task UpdateRelation<T>(T item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }

        public Task<T> GetItemAvecRelations<T>(T item) where T : new()
        {
            PropertyInfo x = (item.GetType().GetProperty("ID"));
            int nbi = Convert.ToInt32(x.GetValue(item));
            return Database.GetWithChildrenAsync<T>(nbi);
        }
        public Task<T> GetRelation<T>(T item) where T : new()
        {
            return Database.GetWithChildrenAsync<T>(item);
        }
        #endregion

    }
}
