using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE120IPD1 : IEntityTypeConfiguration<E120IPD1>
    {
        public void Configure(EntityTypeBuilder<E120IPD1> entity)
        {
            entity.HasKey(e => new { e.Codemp, e.Codfil, e.Numped, e.Seqipd })
                .HasName("cp_e120ipd")
                .IsClustered(false);

            entity.ToTable("e120ipd", "sapiens", tb => tb.HasTrigger("T120IPDD"));

            entity.HasIndex(e => new { e.Codpro, e.Codder, e.Datent, e.Codemp, e.Codfil }, "e120ipdindice2");

            entity.HasIndex(e => new { e.Datent, e.Codpro, e.Codder, e.Codemp, e.Codfil }, "e120ipdindice3");

            entity.HasIndex(e => new { e.Codemp, e.Filnfc, e.Fornfc, e.Snfnfc, e.Numnfc, e.Seqipc, e.Codfil }, "e120ipdindice4");

            entity.HasIndex(e => new { e.Empocp, e.Filocp, e.Numocp, e.Seqipo }, "e120ipdindice5");

            entity.HasIndex(e => new { e.Codemp, e.Filctr, e.Ctrcvs, e.Cptcvs, e.Seqcvs }, "e120ipdindice6");

            entity.HasIndex(e => new { e.Qtdres, e.Sitipd, e.Resest, e.Coddep }, "e120ipdindice7");

            entity.HasIndex(e => new { e.Codemp, e.Coddep }, "e120ipdindice8");

            entity.Property(e => e.Codemp).HasColumnName("codemp");
            entity.Property(e => e.Codfil).HasColumnName("codfil");
            entity.Property(e => e.Numped).HasColumnName("numped");
            entity.Property(e => e.Seqipd).HasColumnName("seqipd");
            entity.Property(e => e.Agrnec)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("agrnec");
            entity.Property(e => e.Agrpai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("agrpai");
            entity.Property(e => e.Alicff)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("alicff");
            entity.Property(e => e.Aliipi)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("aliipi");
            entity.Property(e => e.Alipif)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("alipif");
            entity.Property(e => e.Basidf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("basidf");
            entity.Property(e => e.Brdman)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("brdman");
            entity.Property(e => e.Cmpkit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cmpkit");
            entity.Property(e => e.Codagc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagc");
            entity.Property(e => e.Codagr).HasColumnName("codagr");
            entity.Property(e => e.Codavc).HasColumnName("codavc");
            entity.Property(e => e.Codbar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codbar");
            entity.Property(e => e.Codccu)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("codccu");
            entity.Property(e => e.Codclc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codclc");
            entity.Property(e => e.Codcnv).HasColumnName("codcnv");
            entity.Property(e => e.Coddep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("coddep");
            entity.Property(e => e.Codder)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("codder");
            entity.Property(e => e.Codfam)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("codfam");
            entity.Property(e => e.Codfin).HasColumnName("codfin");
            entity.Property(e => e.Codfpj).HasColumnName("codfpj");
            entity.Property(e => e.Codfxa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codfxa");
            entity.Property(e => e.Codlot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codlot");
            entity.Property(e => e.Codmar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codmar");
            entity.Property(e => e.Codmcp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codmcp");
            entity.Property(e => e.Codmoe)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codmoe");
            entity.Property(e => e.Codmot).HasColumnName("codmot");
            entity.Property(e => e.Codpgr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codpgr");
            entity.Property(e => e.Codpro)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codpro");
            entity.Property(e => e.Codpvp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("codpvp");
            entity.Property(e => e.Codrep).HasColumnName("codrep");
            entity.Property(e => e.Codstc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstc");
            entity.Property(e => e.Codstp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstp");
            entity.Property(e => e.Codstr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstr");
            entity.Property(e => e.Codtic)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtic");
            entity.Property(e => e.Codtpr)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codtpr");
            entity.Property(e => e.Codtrd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtrd");
            entity.Property(e => e.Codtst)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtst");
            entity.Property(e => e.Cotmfp)
                .HasColumnType("numeric(19, 10)")
                .HasColumnName("cotmfp");
            entity.Property(e => e.Cotmoe)
                .HasColumnType("numeric(19, 10)")
                .HasColumnName("cotmoe");
            entity.Property(e => e.Cplipd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cplipd");
            entity.Property(e => e.Cptcvp)
                .HasColumnType("datetime")
                .HasColumnName("cptcvp");
            entity.Property(e => e.Cptcvs)
                .HasColumnType("datetime")
                .HasColumnName("cptcvs");
            entity.Property(e => e.Ctafin).HasColumnName("ctafin");
            entity.Property(e => e.Ctared).HasColumnName("ctared");
            entity.Property(e => e.Ctrcvp).HasColumnName("ctrcvp");
            entity.Property(e => e.Ctrcvs).HasColumnName("ctrcvs");
            entity.Property(e => e.Datane)
                .HasColumnType("datetime")
                .HasColumnName("datane");
            entity.Property(e => e.Datapr)
                .HasColumnType("datetime")
                .HasColumnName("datapr");
            entity.Property(e => e.Datcpt)
                .HasColumnType("datetime")
                .HasColumnName("datcpt");
            entity.Property(e => e.Datent)
                .HasColumnType("datetime")
                .HasColumnName("datent");
            entity.Property(e => e.Datger)
                .HasColumnType("datetime")
                .HasColumnName("datger");
            entity.Property(e => e.Datmfp)
                .HasColumnType("datetime")
                .HasColumnName("datmfp");
            entity.Property(e => e.Datmoe)
                .HasColumnType("datetime")
                .HasColumnName("datmoe");
            entity.Property(e => e.Datpoc)
                .HasColumnType("datetime")
                .HasColumnName("datpoc");
            entity.Property(e => e.Dscprm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("dscprm");
            entity.Property(e => e.Empocp).HasColumnName("empocp");
            entity.Property(e => e.Fecmoe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("fecmoe");
            entity.Property(e => e.Filctr).HasColumnName("filctr");
            entity.Property(e => e.Filnco).HasColumnName("filnco");
            entity.Property(e => e.Filnfc).HasColumnName("filnfc");
            entity.Property(e => e.Filocp).HasColumnName("filocp");
            entity.Property(e => e.Filprd).HasColumnName("filprd");
            entity.Property(e => e.Filrem).HasColumnName("filrem");
            entity.Property(e => e.Fornfc).HasColumnName("fornfc");
            entity.Property(e => e.Gercga)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gercga");
            entity.Property(e => e.Gernec).HasColumnName("gernec");
            entity.Property(e => e.Horapr).HasColumnName("horapr");
            entity.Property(e => e.Horger).HasColumnName("horger");
            entity.Property(e => e.Icmade)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("icmade");
            entity.Property(e => e.Icmafc)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("icmafc");
            entity.Property(e => e.Icmaor)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("icmaor");
            entity.Property(e => e.Icmbde)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmbde");
            entity.Property(e => e.Icmvde)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvde");
            entity.Property(e => e.Icmvfc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvfc");
            entity.Property(e => e.Icmvor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvor");
            entity.Property(e => e.Idxgrd).HasColumnName("idxgrd");
            entity.Property(e => e.Indaed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indaed");
            entity.Property(e => e.Indape).HasColumnName("indape");
            entity.Property(e => e.Indbrd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indbrd");
            entity.Property(e => e.Indipm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indipm");
            entity.Property(e => e.Indpce)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indpce");
            entity.Property(e => e.Indpcr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indpcr");
            entity.Property(e => e.Ipvrem).HasColumnName("ipvrem");
            entity.Property(e => e.Motdes).HasColumnName("motdes");
            entity.Property(e => e.Nctlcl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nctlcl");
            entity.Property(e => e.Nfvrem).HasColumnName("nfvrem");
            entity.Property(e => e.Noccl1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("noccl1");
            entity.Property(e => e.Noccl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("noccl2");
            entity.Property(e => e.Noccl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("noccl3");
            entity.Property(e => e.Nosfcl).HasColumnName("nosfcl");
            entity.Property(e => e.Nosicl).HasColumnName("nosicl");
            entity.Property(e => e.Nrecli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nrecli");
            entity.Property(e => e.Numctr).HasColumnName("numctr");
            entity.Property(e => e.Numnco).HasColumnName("numnco");
            entity.Property(e => e.Numnfc).HasColumnName("numnfc");
            entity.Property(e => e.Numocp).HasColumnName("numocp");
            entity.Property(e => e.Numprj).HasColumnName("numprj");
            entity.Property(e => e.Numrec).HasColumnName("numrec");
            entity.Property(e => e.Obsipd)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("obsipd");
            entity.Property(e => e.Obsmot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("obsmot");
            entity.Property(e => e.Orires)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("orires");
            entity.Property(e => e.Pedcli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pedcli");
            entity.Property(e => e.Pedprv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("pedprv");
            entity.Property(e => e.Peracr)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peracr");
            entity.Property(e => e.Percff)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("percff");
            entity.Property(e => e.Percom)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("percom");
            entity.Property(e => e.Percrt)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("percrt");
            entity.Property(e => e.Percsl)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("percsl");
            entity.Property(e => e.Perdif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdif");
            entity.Property(e => e.Perds1)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds1");
            entity.Property(e => e.Perds2)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds2");
            entity.Property(e => e.Perds3)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds3");
            entity.Property(e => e.Perds4)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds4");
            entity.Property(e => e.Perds5)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds5");
            entity.Property(e => e.Perdsc)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perdsc");
            entity.Property(e => e.Pericm)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("pericm");
            entity.Property(e => e.Peridf)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peridf");
            entity.Property(e => e.Peripi)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peripi");
            entity.Property(e => e.Perirf)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perirf");
            entity.Property(e => e.Perjur)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perjur");
            entity.Property(e => e.Permgc)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("permgc");
            entity.Property(e => e.Perofe)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perofe");
            entity.Property(e => e.Perour)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perour");
            entity.Property(e => e.Perpif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perpif");
            entity.Property(e => e.Perpit)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perpit");
            entity.Property(e => e.Prebru)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("prebru");
            entity.Property(e => e.Prefix)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prefix");
            entity.Property(e => e.Preuni)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("preuni");
            entity.Property(e => e.Preven)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("preven");
            entity.Property(e => e.Proent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("proent");
            entity.Property(e => e.Promon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("promon");
            entity.Property(e => e.Qtdabe)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdabe");
            entity.Property(e => e.Qtdaen)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdaen");
            entity.Property(e => e.Qtdbcf)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbcf");
            entity.Property(e => e.Qtdbip)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbip");
            entity.Property(e => e.Qtdbpf)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbpf");
            entity.Property(e => e.Qtdcan)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdcan");
            entity.Property(e => e.Qtdfat)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdfat");
            entity.Property(e => e.Qtdnlp)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdnlp");
            entity.Property(e => e.Qtdped)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdped");
            entity.Property(e => e.Qtdpoc)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdpoc");
            entity.Property(e => e.Qtdppf)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdppf");
            entity.Property(e => e.Qtdrae)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdrae");
            entity.Property(e => e.Qtdres)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdres");
            entity.Property(e => e.Qtdven)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("qtdven");
            entity.Property(e => e.Resest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("resest");
            entity.Property(e => e.Resman)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("resman");
            entity.Property(e => e.Retmat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retmat");
            entity.Property(e => e.Senapr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senapr");
            entity.Property(e => e.Seqctr).HasColumnName("seqctr");
            entity.Property(e => e.Seqcvp).HasColumnName("seqcvp");
            entity.Property(e => e.Seqcvs).HasColumnName("seqcvs");
            entity.Property(e => e.Seqipc).HasColumnName("seqipc");
            entity.Property(e => e.Seqipo).HasColumnName("seqipo");
            entity.Property(e => e.Seqisp).HasColumnName("seqisp");
            entity.Property(e => e.Seqnco).HasColumnName("seqnco");
            entity.Property(e => e.Seqpcl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("seqpcl");
            entity.Property(e => e.Seqrei).HasColumnName("seqrei");
            entity.Property(e => e.Seqrem).HasColumnName("seqrem");
            entity.Property(e => e.Sitipd).HasColumnName("sitipd");
            entity.Property(e => e.Snfnco)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("snfnco");
            entity.Property(e => e.Snfnfc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("snfnfc");
            entity.Property(e => e.Snfrem)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("snfrem");
            entity.Property(e => e.Tipcur).HasColumnName("tipcur");
            entity.Property(e => e.Tnspro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tnspro");
            entity.Property(e => e.Unimed)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unimed");
            entity.Property(e => e.Univen)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("univen");
            entity.Property(e => e.UsuEstemp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_estemp");
            entity.Property(e => e.UsuPespro)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_pespro");
            entity.Property(e => e.UsuPesrea)
                .HasColumnType("numeric(15, 12)")
                .HasColumnName("usu_pesrea");
            entity.Property(e => e.UsuQtdabe)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_qtdabe");
            entity.Property(e => e.UsuQtdemb).HasColumnName("usu_qtdemb");
            entity.Property(e => e.UsuQtdfat)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_qtdfat");
            entity.Property(e => e.UsuQtdpon)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_qtdpon");
            entity.Property(e => e.UsuQtdven)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_qtdven");
            entity.Property(e => e.UsuVenabe)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_venabe");
            entity.Property(e => e.Usuapr).HasColumnName("usuapr");
            entity.Property(e => e.Usuger).HasColumnName("usuger");
            entity.Property(e => e.Varser)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("varser");
            entity.Property(e => e.Vlrbcf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbcf");
            entity.Property(e => e.Vlrbcl)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbcl");
            entity.Property(e => e.Vlrbco)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbco");
            entity.Property(e => e.Vlrbct)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbct");
            entity.Property(e => e.Vlrbic)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbic");
            entity.Property(e => e.Vlrbip)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbip");
            entity.Property(e => e.Vlrbir)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbir");
            entity.Property(e => e.Vlrbor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbor");
            entity.Property(e => e.Vlrbpf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbpf");
            entity.Property(e => e.Vlrbpt)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbpt");
            entity.Property(e => e.Vlrbru)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbru");
            entity.Property(e => e.Vlrbsc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbsc");
            entity.Property(e => e.Vlrbsi)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbsi");
            entity.Property(e => e.Vlrbsp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrbsp");
            entity.Property(e => e.Vlrcff)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrcff");
            entity.Property(e => e.Vlrcom)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrcom");
            entity.Property(e => e.Vlrcrt)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrcrt");
            entity.Property(e => e.Vlrcsl)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrcsl");
            entity.Property(e => e.Vlrdar)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrdar");
            entity.Property(e => e.Vlrds1)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds1");
            entity.Property(e => e.Vlrds2)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds2");
            entity.Property(e => e.Vlrds3)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds3");
            entity.Property(e => e.Vlrds4)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds4");
            entity.Property(e => e.Vlrds5)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds5");
            entity.Property(e => e.Vlrdsc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrdsc");
            entity.Property(e => e.Vlrdzf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrdzf");
            entity.Property(e => e.Vlremb)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlremb");
            entity.Property(e => e.Vlrenc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrenc");
            entity.Property(e => e.Vlrfin)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrfin");
            entity.Property(e => e.Vlrfrd)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrfrd");
            entity.Property(e => e.Vlrfre)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrfre");
            entity.Property(e => e.Vlricd)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlricd");
            entity.Property(e => e.Vlricm)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlricm");
            entity.Property(e => e.Vlrics)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrics");
            entity.Property(e => e.Vlridf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlridf");
            entity.Property(e => e.Vlripi)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlripi");
            entity.Property(e => e.Vlrirf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrirf");
            entity.Property(e => e.Vlrliq)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrliq");
            entity.Property(e => e.Vlrlou)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrlou");
            entity.Property(e => e.Vlrlpr)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrlpr");
            entity.Property(e => e.Vlrofe)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrofe");
            entity.Property(e => e.Vlroud)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlroud");
            entity.Property(e => e.Vlrour)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrour");
            entity.Property(e => e.Vlrout)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrout");
            entity.Property(e => e.Vlrpif)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrpif");
            entity.Property(e => e.Vlrpit)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrpit");
            entity.Property(e => e.Vlrris)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrris");
            entity.Property(e => e.Vlrseg)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrseg");
            entity.Property(e => e.Vlrstc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrstc");
            entity.Property(e => e.Vlrstp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrstp");
        }
    }
}
