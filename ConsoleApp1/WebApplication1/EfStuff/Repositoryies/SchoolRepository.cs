﻿using WebApplication1.EfStuff.Model;
using WebApplication1.EfStuff.Repositoryies.Interface;

namespace WebApplication1.EfStuff.Repositoryies
{
	public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        public SchoolRepository(KzDbContext kzDbContext) : base(kzDbContext) { }
    }
}
