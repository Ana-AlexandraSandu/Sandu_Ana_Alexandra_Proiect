using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sandu_Ana_Alexandra_Proiect.Data;


namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class VacantaCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Sandu_Ana_Alexandra_ProiectContext context,
        Vacanta vacanta)
        {
            var allCategories = context.Categorie;
            var categoriiVacanta = new HashSet<int>(
            vacanta.CategoriiVacanta.Select(c => c.VacantaID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = categoriiVacanta.Contains(cat.ID)
                });
            }
        }
        public void UpdateVacantaCategories(Sandu_Ana_Alexandra_ProiectContext context,
        string[] selectedCategories, Vacanta vacantaToUpdate)
        {
            if (selectedCategories == null)
            {
                vacantaToUpdate.CategoriiVacanta = new List<CategorieVacanta>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiVacanta = new HashSet<int>
            (vacantaToUpdate.CategoriiVacanta.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriiVacanta.Contains(cat.ID))
                    {
                        vacantaToUpdate.CategoriiVacanta.Add(
                        new CategorieVacanta
                        {
                            VacantaID = vacantaToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (categoriiVacanta.Contains(cat.ID))
                    {
                        CategorieVacanta courseToRemove
                        = vacantaToUpdate
                        .CategoriiVacanta
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }


}