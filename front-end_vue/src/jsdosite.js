export default {
  data() {
    return {
      totalData: [], // Armazena os dados totais retornados da API
      mediaData: [], // Armazena os dados da média de emolumentos
      errorMessage: '', // Armazena mensagens de erro, se houver
      loadingTotal: false, 
      loadingMedia: false, 
      loadingIntro: true 
    };
  },
  methods: {
    // Método assíncrono para buscar os dados totais da API
    async fetchTotalData() {
      this.loadingTotal = true; 
      this.errorMessage = ''; 

      try {
        // Faz uma requisição para a API para buscar os dados totais
        const response = await fetch('https://localhost:7146/api/MostraDadosBD');
        if (!response.ok) {
          throw new Error('Erro ao buscar dados da API'); // Lança um erro se a resposta não for OK
        }
        // Converte a resposta JSON e armazena em totalData
        this.totalData = await response.json();
      } catch (error) {
        this.errorMessage = `Dados não encontrados`;
      } finally {
        this.loadingTotal = false;
      }
    },
    // Método assíncrono para buscar a média de emolumentos da API
    async fetchMediaData() {
      this.loadingMedia = true; 
      this.errorMessage = ''; 

      try {
        // Faz uma requisição para a API para buscar a média de emolumentos
        const response = await fetch('https://localhost:7146/api/MostraDadosBD/media');
        if (!response.ok) {
          throw new Error('Erro ao buscar média de emolumentos');
        }
        // A mesma coisa que a de cima, só que na tabela abaixo
        this.mediaData = await response.json();
      } catch (error) {
        this.errorMessage = `Dados não encontrados`;
      } finally {
        this.loadingMedia = false;
      }
    }
  },
  mounted() {
    // Método chamado quando o componente é montado
    // Simula um carregamento de 3 segundos
    setTimeout(() => {
      this.loadingIntro = false; // Esconde a introdução após o carregamento
      // Chama os métodos para buscar dados totais e média
      this.fetchTotalData();
      this.fetchMediaData();
    }, 3000);
  }
};