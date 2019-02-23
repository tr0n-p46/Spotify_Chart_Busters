<template>
  <div>
   <p class="homeText">
    Welcome To Spotify Top 50 Chartbusters
    </p>
    <b-row>
      <b-col
        md="2"
        offset-md="10">
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="10">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th># Rank</th>
                <th>Name</th>
                <th>Artists</th>
                <th>Details</th>
              </tr>
            </thead>
            <tbody>
             <chartbuster
                v-for="chartbuster in chartbusters"
                :key="chartbuster.id"
                :chartbuster="chartbuster"
                @details="detailsChartbuster"/>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import ChartbustersService from '@/api-services/chartbusters.service'
import Chartbuster from '@/components/chartbusters/chartbuster'
export default {
  name: 'Chartbusters',
  components: {
    Chartbuster
  },
  data () {
    return {
      chartbusters: []
    }
  },
  created () {
    ChartbustersService.getAll().then((response) => {
      this.chartbusters = response.data.data
    })
  },
  methods: {
    detailsChartbuster (chartbusterId) {
      this.$router.push({ name: 'ChartbusterDetails', params: { id: chartbusterId } })
    }
  }
}
</script>
<style scoped>
.homeText{
    font-size: 35px;
    color: black;
    top:15px;
    position:relative;
    text-shadow: 2px 2px 2px gray;
}
</style>
