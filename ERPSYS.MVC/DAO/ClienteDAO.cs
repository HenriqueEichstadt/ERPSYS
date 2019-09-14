using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSYS.MVC.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        public void Add(ICliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Add(cliente);
                dbSet.SaveChanges();
            }
        }

        public void Update(ICliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Update(cliente);
                dbSet.SaveChanges();
            }
        }

        public void Delete(ICliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Remove(cliente);
                dbSet.SaveChanges();
            }
        }

        public ICliente GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES.FirstOrDefault(c => c.Id == id);
            }
        }

        public IList<Cliente> ListActives()
        {
            using (var dbSet = new ApplicationContext())
            {
                var query = $@"SELECT * FROM CLIENTES A
INNER JOIN PESSOAS B ON A.PESSOA = B.ID
WHERE B.ATIVO = TRUE";
                return dbSet.CLIENTES.FromSql(query).ToList();
            }
        }

        public IList<Cliente> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES.FromSql(
@"
SELECT
   A.ID,
   B.NOME,
   B.CPF,
   A.PONTOS,
   A.ATIVO,
   A.DATAINCLUSAO,
   A.DATAALTERACAO,
   INC.NOME,
   ALT.NOME 
 FROM CLIENTES A
   INNER JOIN PESSOAS B ON A.PESSOA = B.ID
   LEFT JOIN USUARIOS INC ON A.USUARIOINCLUSAO = INC.ID
   LEFT JOIN USUARIOS ALT ON A.USUARIOALTERACAO = ALT.ID")
                    .ToList();
            }
        }
    }
}