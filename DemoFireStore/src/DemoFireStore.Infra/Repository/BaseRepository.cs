using DemoFireStore.Domain.Domain;
using DemoFireStore.Infra.Interface;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoFireStore.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        private string diretorio = "L:\\DemoFireStore\\demofirebase-665d8-ee6127dc0781.json";
        private string projectId;
        private FirestoreDb _fireStoreDb;

        public BaseRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", diretorio);
            projectId = "demofirebase-665d8";
            _fireStoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<TEntity> Create(Dictionary<string, object> obj)
        {
            DocumentReference addedDocRef = await _fireStoreDb.Collection(typeof(TEntity).Name).AddAsync(obj);

            return JsonSerializer.Deserialize<TEntity>(JsonSerializer.Serialize(obj));
        }

        public async Task<TEntity> Update(Dictionary<string, object> obj)
        {
            var pessoa = JsonSerializer.Deserialize<TEntity>(JsonSerializer.Serialize(obj));
            //if (pessoa is null) return null;
            DocumentReference getDocRef = _fireStoreDb.Collection(typeof(TEntity).Name).Document(pessoa.Id);
            DocumentSnapshot documentSnapshot = await getDocRef.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                
                await getDocRef.SetAsync(obj, SetOptions.Overwrite);
                return pessoa;

            }
            return null;
        }

        public async Task<bool> Delete(string id)
        {
            DocumentReference getDocRef = _fireStoreDb.Collection(typeof(TEntity).Name).Document(id);
            DocumentSnapshot documentSnapshot = await getDocRef.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                await getDocRef.DeleteAsync();
                return true;
            }


            return false;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            Query query = _fireStoreDb.Collection(typeof(TEntity).Name);
            QuerySnapshot QuerySnapshot = await query.GetSnapshotAsync();
            List<TEntity> entitys = new();

            foreach (DocumentSnapshot documentSnapshot in QuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> entity = documentSnapshot.ToDictionary();
                    string json = JsonSerializer.Serialize(entity);
                    var newEntity = JsonSerializer.Deserialize<TEntity>(json);
                    newEntity.Id = documentSnapshot.Id;
                    entitys.Add(newEntity);
                }
            }

            return entitys;
        }

        public async Task<TEntity?> GetById(string id)
        {
            DocumentReference getDocRef = _fireStoreDb.Collection(typeof(TEntity).Name).Document(id);
            DocumentSnapshot documentSnapshot = await getDocRef.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Dictionary<string, object> entity = documentSnapshot.ToDictionary();
                string json = JsonSerializer.Serialize(entity);
                var newEntity = JsonSerializer.Deserialize<TEntity>(json);
                newEntity.Id = documentSnapshot.Id;
                return newEntity;
            }
            return null;
        }

       
    }
}
