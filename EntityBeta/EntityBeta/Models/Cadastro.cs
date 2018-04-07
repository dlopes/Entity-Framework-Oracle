using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//http://www.macoratti.net/17/06/ef6_relent1.htm
//https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
//https://ospsoft.wordpress.com/2014/12/17/code-first-data-annotations/
//https://stackoverflow.com/questions/5465686/ef-4-1-code-first-non-null-value-of-type-datetime-issue
//Atenção:
// Intalar no nuguet o paconte Oracle.ManagedDataAccess.EntityFramework para o provider e configurar o 
//Web.config
namespace EntityBeta.Models
{
    [Table("DB.CADASTRO")]
    public class Cadastro
    {
        //Chave primaria composta
        [Key, Column(Order = 1)]
        public virtual int COD_PESSOA { get; set; }

        [Key, Column(Order = 2)]
        public virtual string CPF_CGC { get; set; }

        public virtual string NOME_PESSOA { get; set; }

        public virtual DateTime DATA_INCLUSAO { get; set; }
   
        public virtual Byte[] BLOB_IMAGEM { get; set; }
    }
}