﻿using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface ICandidatAccessLayer
    {
        Task<int> AddAsync(Candidat candidat);

        Task<bool> UpdateAsync(Candidat candidat);

        void Delete(int candidatId);

        Candidat Get(int candidatId);

        List<Candidat> GetAll();

    }
}
