public class Distrito
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public Municipio Municipio { get; set; } = new Municipio();
}

public class Municipio
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public Microrregiao Microrregiao { get; set; } = new Microrregiao();
    public RegiaoImediata RegiaoImediata { get; set; } = new RegiaoImediata();
}

public class Microrregiao
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public Mesorregiao Mesorregiao { get; set; } = new Mesorregiao();
}

public class Mesorregiao
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public UF UF { get; set; } = new UF();
}

public class UF
{
    public int Id { get; set; }
    public string Sigla { get; set; } = "";
    public string Nome { get; set; } = "";
    public Regiao Regiao { get; set; } = new Regiao();
}

public class Regiao
{
    public int Id { get; set; }
    public string Sigla { get; set; } = "";
    public string Nome { get; set; } = "";
}

public class RegiaoImediata
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public RegiaoIntermediaria RegiaoIntermediaria { get; set; } = new RegiaoIntermediaria();
}

public class RegiaoIntermediaria
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public UF UF { get; set; } = new UF();
}

