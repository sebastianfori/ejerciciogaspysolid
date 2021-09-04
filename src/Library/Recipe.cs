//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    
    /*
    Basandonos en el patron Expert, agregamos el metodo GetProductionCost en la clase Recipe ya que es la que
    tiene toda la informacion de la receta.
    Ademas cumple con el principio SRP porque el costo es parte de la receta lo cual ya era parte de la 
    responsabilidad de la clase Recipe.
    */
    public class Recipe
    {
        
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public double GetProductionCost()
        {
            double costoInsumos = 0;
            double costoEquipamiento = 0;

            foreach (Step step in steps)
            {
                costoInsumos += step.Input.UnitCost*step.Quantity;
                costoEquipamiento+= (step.Time/60)*step.Equipment.HourlyCost;

            }
            return costoInsumos+costoEquipamiento;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total: {this.GetProductionCost()}");
        }
    }
}