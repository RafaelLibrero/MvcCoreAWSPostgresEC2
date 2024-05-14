using Microsoft.EntityFrameworkCore;
using MvcCoreAWSPostgresEC2.Data;
using MvcCoreAWSPostgresEC2.Models;

namespace MvcCoreAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento>
            FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos
                .FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }

        public async Task InsertDepartamentoAsync
            (Departamento dept)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = dept.IdDepartamento,
                Nombre = dept.Nombre,
                Localidad = dept.Localidad
            };
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
