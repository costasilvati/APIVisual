using System;

namespace CartoesAPI.Model
{
    public class Funcionario : Pessoa{
        public double salario { get; set; }

        public Funcionario(int rg, string nome, double salario):base(rg, nome)
        {
            this.salario = salario;
        }
        public double obterSalario(double percentualAcrescimo)
        {
            double salarioReajustado = 
                    salario + (salario*percentualAcrescimo)/100;
        }
        public double obterSalario (double adicional, double desconto)
        {
            return (this.salario+adicional) - desconto;
        }
    }
}