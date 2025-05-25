<template>
  <div>
    <!-- Introdução -->
    <div v-if="loadingIntro" class="intro text-center">
      <h1>Bem-vindo ao Bahia Asset</h1>
      <p>Estamos carregando as informações...</p>
      <div class="spinner-border" role="status"></div>
    </div>

    <!--Conteúdo principal-->

    <div v-else>

      <!--Submenu-->

      <nav class="navbar">
        <ul>
          <li class="logo-item">
            <a href="#">
              <img src="logo-bahia-em-breve.png" alt="Bahia Logo" class="logo">
            </a>
          </li>
          <li>
            <a href="#">SERVIÇOS</a>
            <ul class="submenu">
              <li><a href="#">CONSULTORIA</a></li>
              <li><a href="#">GESTÃO DE ATIVOS</a></li>
              <li><a href="#">ANÁLISES</a></li>
            </ul>
          </li>
          <li>
            <a href="#">INVISTA</a>
          </li>
          <li>
            <a href="#">CONTATO</a>
          </li>
        </ul>
      </nav>

      <div class="container">
        <h1 class="text-center"></h1>

        <section class="text-center">
          <h2>Emolumentos Totais por Data</h2>

          <div v-if="loadingTotal" class="text-center">
            <div class="spinner-border" role="status"></div>
          </div>

          <p v-if="errorMessage" class="text-danger">{{ errorMessage }}</p>

          <!--Tabela com as informações do Banco de Dados-->

          <table v-if="totalData.length" class="table table-striped table-bordered mx-auto" style="max-width: 80%;">
            <thead class="thead-dark">
              <tr>
                <th>Total</th>
                <th>Data</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in totalData" :key="item.DATA_TRADE">
                <td>{{ item.TOTAL }}</td>
                <td>{{ new Date(item.DATA_TRADE).toLocaleDateString('pt-BR') }}</td>
              </tr>
            </tbody>
          </table>

          <button class="btn btn-danger" @click="fetchTotalData">Recarregar Totais</button>
        </section>

        <section class="text-center">

          <h2>Média de Emolumentos por Ativo</h2>

          <div v-if="loadingMedia" class="text-center">
            <div class="spinner-border" role="status"></div>
          </div>
          
          <p v-if="errorMessage" class="text-danger">{{errorMessage}}</p>

          <!--Tabela com as informações do Banco de Dados-->

          <table v-if="mediaData.length" class="table table-striped table-bordered mx-auto" style="max-width: 80%;">
            <thead class="thead-dark">
              <tr>
                <th>Média</th>
                <th>Ativo</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in mediaData" :key="item.ATIVO">
                <td>{{ item.MEDIA }}</td>
                <td>{{ item.ATIVO }}</td>
              </tr>
            </tbody>
          </table>

          <button class="btn btn-danger" @click="fetchMediaData">Recarregar Médias</button>
        </section>
      </div>

      <footer class="footer">
        <div class="social-icons">
          <a href="#"><img src="linkedin.png" alt="Linkedin" /></a>
        </div>
        <p>&copy; 2024 Bahia Asset. Todos os direitos reservados.</p>
      </footer>
    </div>
  </div>
</template>

<script src="./jsdosite.js"></script>
<link rel="stylesheet" src="./cssdosite.css">