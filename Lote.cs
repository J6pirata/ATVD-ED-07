using System;

public class Lote
{
    
    private int id;
    private int qtde;
    private DateTime venc;

    
    public Lote()
    {
        
        id = 0;
        qtde = 0;
        venc = DateTime.Now;
    }

    
    public Lote(int id, int qtde, DateTime venc)
    {
        this.id = id;
        this.qtde = qtde;
        this.venc = venc;
    }

    public override string ToString()
    {
        return $"{id}-{qtde}-{venc:dd/MM/yyyy}";
    }

    // Properties for attributes
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public int Qtde
    {
        get { return qtde; }
        set { qtde = value; }
    }

    public DateTime Venc
    {
        get { return venc; }
        set { venc = value; }
    }
}