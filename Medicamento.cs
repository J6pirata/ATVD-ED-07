using System;
using System.Collections.Generic;

public class Medicamento
{
    // Attributes
    private int id;
    private string nome;
    private string laboratorio;
    private Queue<Lote> lotes;

    public Medicamento()
    {
        
        id = 0;
        nome = string.Empty;
        laboratorio = string.Empty;
        lotes = new Queue<Lote>();
    }

  
    public Medicamento(int id, string nome, string laboratorio)
    {
        this.id = id;
        this.nome = nome;
        this.laboratorio = laboratorio;
        lotes = new Queue<Lote>();
    }

    
    public int QtdeDisponivel()
    {
        int disponibilidadeTotal = 0;
        foreach (Lote lote in lotes)
        {
            disponibilidadeTotal += lote.Qtde;
        }
        return disponibilidadeTotal;
    }

    
    public void Comprar(Lote lote)
    {
        lotes.Enqueue(lote);
    }

    
    public bool Vender(int qtde)
    {
        if (qtde <= QtdeDisponivel())
        {
            while (qtde > 0)
            {
                
                Lote loteAtual = lotes.Peek();
                if (loteAtual.Qtde >= qtde)
                {
                    loteAtual.Qtde -= qtde;
                    qtde = 0;
                    if (loteAtual.Qtde == 0)
                    {
                        lotes.Dequeue(); 
                    }
                }
                else
                {
                    qtde -= loteAtual.Qtde;
                    lotes.Dequeue();
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

   
    public override string ToString()
    {
        return $"{id}-{nome}-{laboratorio}-{QtdeDisponivel()}";
    }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return id == ((Medicamento)obj).id;
    }
}