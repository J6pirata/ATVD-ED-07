using System;
using System.Collections.Generic;

public class Medicamentos
{
    
    private List<Medicamento> listaMedicamentos;


    public Medicamentos()
    {
        listaMedicamentos = new List<Medicamento>();
    }

   
    public void Adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

  
    public bool Deletar(Medicamento medicamento)
    {
        if (medicamento.QtdeDisponivel() == 0)
        {
            return listaMedicamentos.Remove(medicamento);
        }
        else
        {
            return false;
        }
    }

   
    public Medicamento Pesquisar(Medicamento medicamento)
    {
        foreach (Medicamento m in listaMedicamentos)
        {
            if (m.Equals(medicamento))
            {
                return m;
            }
        }
        
        return new Medicamento();
    }


    public List<Medicamento> ListaMedicamentos
    {
        get { return listaMedicamentos; }
    }
}
