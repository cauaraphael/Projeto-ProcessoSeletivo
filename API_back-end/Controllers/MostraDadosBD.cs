using Microsoft.AspNetCore.Mvc; 
using Newtonsoft.Json; 
using System.Data; 
using System.Data.SqlClient; 

namespace APIBahia.Controllers 
{
    [Route("api/[controller]")] // Define a rota base para este controlador
    [ApiController] 
    public class MostraDadosBDController : ControllerBase 
    {
        // GET: api/mostradadosBD
        [HttpGet] 
        public IActionResult MostraDadosBD()
        {
            
            string connectionString = "SERVER=localhost;DATABASE=teste;UID=;Trusted_Connection=yes";
            DataTable customerTable = new DataTable("TotaisEMedias");
            using (SqlConnection _con = new SqlConnection(connectionString))
            // Um DataTable para armazenar os resultados da consulta
            

            
            {
              
                string queryStatement = "SELECT SUM(EMOLUMENTO) AS TOTAL, DATA_TRADE FROM ORDEM GROUP BY DATA_TRADE";

                // Cria um comando SQL com a consulta e a conexão
                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    // Cria um SqlDataAdapter para preencher o DataTable com os resultados da consulta
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _con.Open(); // Abre a conexão com o banco de dados
                    _dap.Fill(customerTable); // Executa a consulta e preenche o DataTable
                }
            }

            // Serializa o DataTable em JSON
            string JSONresult = JsonConvert.SerializeObject(customerTable);
            // Retorna a resposta HTTP 200 (OK) com o JSON resultante
            return Ok(JSONresult);
        }

        // GET: api/mostradadosbd/media
        [HttpGet("media")] // Indica que este método responderá a requisições GET na rota api/todoitems/media
        public IActionResult GetMediaEmolumento()
        {
            // String de conexão para acessar o banco de dados preencher de acordo com a suua  rota
            string connectionString = "SERVER=localhost;DATABASE=teste;UID=;Trusted_Connection=yes";
            DataTable mediaTable = new DataTable("MediaEmolumento");
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                
                string queryStatement = "SELECT AVG(EMOLUMENTO) AS MEDIA, ATIVO FROM ORDEM GROUP BY ATIVO";
                // Cria um comando SQL com a consulta e a conexão
                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    // Cria um SqlDataAdapter para preencher o DataTable com os resultados da consulta
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                    _con.Open();
                    _dap.Fill(mediaTable); 
                } 
            }

            // Serializa o DataTable em JSON
            string JSONresult = JsonConvert.SerializeObject(mediaTable);
            // Retorna a resposta HTTP 200 (OK) com o JSON resultante
            return Ok(JSONresult);
        }
    }
}