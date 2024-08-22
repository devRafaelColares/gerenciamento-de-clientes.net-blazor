using System.Collections.Generic;

public static class CidadesBrasil
{
    public static readonly List<string> Cidades = new List<string>
    {
        // São Paulo
        "São Paulo", "Guarulhos", "Campinas", "São Bernardo do Campo", "São Caetano do Sul",
        "Osasco", "Santos", "Sorocaba", "Ribeirão Preto", "São José dos Campos",
        "Mauá", "Jundiaí", "Carapicuíba", "Barueri", "Bauru",
        "Limeira", "Piracicaba", "Marília", "Botucatu",
        "Indaiatuba", "Valinhos", "Vinhedo", "Hortolândia",
        "Sumaré", "Atibaia", "Bragança Paulista", "Pindamonhangaba", "Taubaté",
        "Itaquaquecetuba", "Guarujá", "Praia Grande", "Mogi das Cruzes", "Suzano",
        "São Vicente", "Itanhaém", "Bertioga", "Ilhabela", "Caraguatatuba",
        "Ubatuba", "São Roque", "Rio Claro", "Jaboticabal", "Araraquara",
        "São Carlos", "Ourinhos", "Tatuí", "Franca", "Ibitinga",
        "Jaú", "Leme", "Monte Alto", "Bebedouro", "Barretos",
        "Catanduva", "Catu", "Eldorado", "Embu das Artes", "Itapetininga",
        "Lins", "Mogiana", "Paulínia", "São João da Boa Vista",
        "São Sebastião", "Valparaíso", "Votuporanga", "Zacarias",

        // Rio de Janeiro
        "Rio de Janeiro", "Niterói", "São Gonçalo", "Duque de Caxias", "Nova Iguaçu",
        "Teresópolis", "Petrópolis", "Volta Redonda", "Angra dos Reis", "Macaé",
        "Campos dos Goytacazes", "Itaboraí", "Mesquita", "Nilópolis", "Queimados",
        "São João de Meriti", "Paraty", "Cabo Frio", "Arraial do Cabo", "Saquarema",
        "Barra do Piraí", "Barra Mansa", "Resende", "Porto Real", "Conceição de Macabu",
        "Nova Friburgo", "Rio das Ostras", "Mangaratiba", "Japeri", "Maricá",
        "Seropédica", "Santa Maria Madalena", "São Fidélis", "São Pedro da Aldeia", "Itaocara",
        "São Francisco do Itabapoana", "Iguaba Grande", "Araruama", "Casimiro de Abreu", "Cachoeiras de Macacu",
        "São José do Vale do Rio Preto", "Santo Antônio de Pádua", "Bom Jardim", "Cantagalo", "Carmo", "Trajano de Moraes",

        // Espírito Santo
        "Vitória", "Vila Velha", "Serra", "Cariacica", "Linhares", "Colatina", "Guarapari",
        "São Mateus", "Alegre", "Aracruz", "Cachoeiro de Itapemirim", "São Gabriel da Palha",
        "Iconha", "Jerônimo Monteiro", "Mantenópolis", "Nova Venécia", "Pinheiros",
        "Santa Teresa", "São Roque do Canaã", "São Domingos do Norte", "São José do Calçado",
        "Vargem Alta", "Viana", "Marataízes", "Castelo", "Domingos Martins",
        "Fundão", "Pedro Canário", "Serra Dourada", "Santa Leopoldina", "Ibatiba",
        "Água Doce do Norte", "Baixo Guandu", "Boa Esperança",
        "Dores do Rio Preto", "Ponto Belo", "Santa Maria de Jetibá", "São Pedro", "Santo Antônio",

        // Minas Gerais
        "Belo Horizonte", "Uberlândia", "Contagem", "Juiz de Fora", "Betim", "Montes Claros",
        "Uberaba", "Ribeirão das Neves", "Ipatinga", "Governador Valadares", "Sete Lagoas",
        "Divinópolis", "Santa Luzia", "Poços de Caldas", "Varginha", "Patos de Minas",
        "São João del-Rei", "Teófilo Otoni", "Machado", "Pará de Minas", "Nova Lima",
        "Pouso Alegre", "Manhuaçu", "Conselheiro Lafaiete", "Araxá",
        "Itabira", "Boa Esperança", "Formiga", "Janaúba", "Lavras",
        "Nova Serrana", "São Sebastião do Paraíso", "Valadares", "Araguari",
        "Cambuí", "Campo Belo", "Campos Gerais", "Carmo do Rio Claro",
        "Eldorado", "Felício dos Santos", "Ituiutaba", "João Monlevade", "Lagoa da Prata",
        "Nova Ponte", "Paraguaçu", "Pirapora", "Piumhi", "São João Nepomuceno",
        "Vespasiano", "Caldas", "Carmo da Cachoeira", "Santo Antônio do Monte",

        // Norte
        "Manaus", "Belém", "Porto Velho", "Rio Branco", "Boa Vista",
        "Macapá", "São Luís", "Teresina", "Ananindeua", "Santarém",
        "Itaituba", "Marabá", "Parauapebas", "Castanhal", "Altamira",
        "Mocajuba", "Barcarena", "Abadiânia", "São Félix do Xingu", "Tucuruí",
        "Apuí", "Humaitá", "Juruá", "Cruzeiro do Sul", "Eirunepé",
        "Lábrea", "Benjamin Constant", "Jutaí", "Maués", "Coari",
        "Tapauá", "Tabatinga", "Tefé", "Manacapuru",
        "Iranduba", "Novo Airão", "Uarini", "São Gabriel da Cachoeira", "Santa Isabel do Rio Negro",
        "Abaetetuba", "Ourém", "Curuçá", "Oriximiná", "Juruti",
        "Paragominas", "Redenção", "São Geraldo do Araguaia", "Ulianópolis", "Rurópolis",

        // Nordeste
        "Salvador", "Fortaleza", "Recife", "São Luís", "Teresina",
        "Maceió", "Natal", "Aracaju", "João Pessoa", "Vitória da Conquista",
        "Feira de Santana", "Juazeiro", "Campina Grande", "Irecê",
        "Camaçari", "Maragogipe", "Itabuna", "Ilhéus", "Barreiras",
        "Garanhuns", "Caruaru", "Petrolina", "Serra Talhada", "Paulo Afonso",
        "Juazeiro do Norte", "Crato", "Barbalha", "São Raimundo Nonato", "Piripiri",
        "Codó", "Timon", "Imperatriz", "Açailândia", "Caxias",
        "Chapada Diamantina", "São José de Ribamar", "Santa Inês", "Colinas",

        // Sul
        // Paraná
        "Curitiba", "Londrina", "Maringá", "Ponta Grossa", "Foz do Iguaçu",
        "Cascavel", "São José dos Pinhais", "Campo Largo", "Paranaguá", "Apucarana",
        "Guarapuava", "Toledo", "Colombo", "Umuarama", "Itaipulândia",
        "Altônia", "Assis Chateaubriand", "Cianorte", "Curiúva", "Faxinal",
        "Ibiporã", "Jandaia do Sul", "Lapa", "Medianeira", "Marechal Cândido Rondon",
        "Pato Branco", "Prudentópolis", "Quedas do Iguaçu", "Telêmaco Borba", "São Mateus do Sul",
        
        // Santa Catarina
        "Florianópolis", "Joinville", "Blumenau", "Chapecó", "Itajaí",
        "Criciúma", "São José", "Balneário Camboriú", "Jaraguá do Sul",
        "Camboriú", "Herval d'Oeste", "Caçador", "Rio do Sul",
        "São Bento do Sul", "Palhoça", "Araranguá", "Xanxerê", "São Miguel do Oeste",
        "Brusque", "Tubarão", "Joaçaba", "Seara", "Tangará",
        "Concórdia", "Lages", "Videira", "Capinzal", "Santa Cecília",
        
        // Rio Grande do Sul
        "Porto Alegre", "Caxias do Sul", "Pelotas", "Santa Maria", "Novo Hamburgo",
        "Gravataí", "São Leopoldo", "Canoas", "Bagé", "Rio Grande",
        "Santa Cruz do Sul", "Passo Fundo", "Lajeado", "Viamão", "Erechim",
        "Uruguaiana", "Ijuí", "São Borja", "Santo Ângelo", "São Gabriel",
        "Alvorada", "Sapucaia do Sul", "Canela", "Gramado", "Novo Hamburgo",
        "Esteio", "São Francisco de Paula", "Cruz Alta", "Palmeira das Missões", "Sapiranga"
    };
}
