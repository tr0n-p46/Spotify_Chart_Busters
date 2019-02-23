<template>
  <p class="homeText">
    Welcome to Spotify Top 50 chart busters
  </p>
</template>
<script>
import ChartbustersService from '@/api-services/chartbusters.service'
export default {
  name: 'Home',
  created () {
    ChartbustersService.getAll().then((response) => {
      console.log(response.data)
    }).catch((error) => {
      console.log(error.response.data)
    })
  }
}
</script>
<style scoped>
.homeText{
    font-size: 35px;
    color: red;
    text-align: center;
    position: relative;
    top:30px;
    text-shadow: 2px 2px 2px gray;
}
</style>
