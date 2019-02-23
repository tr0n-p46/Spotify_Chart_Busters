<template>
  <div>
    <div class="well">
      <div class="row">
        <div class="col-md-3">
          <strong>Rank:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.rank }}
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>name:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.name }}
        </div>
      </div>
      <div class="row">
        <div class="col-md-3">
          <strong>Artists:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.artists }}
        </div>
      </div>
        <div class="row">
        <div class="col-md-3">
          <strong>Danceability:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.danceability }}
        </div>
      </div>
        <div class="row">
        <div class="col-md-3">
          <strong>Energy:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.energy }}
        </div>
     </div>
        <div class="row">
        <div class="col-md-3">
          <strong>key:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.key }}
        </div>
     </div>
      </div><div class="row">
        <div class="col-md-3">
          <strong>loudness:</strong>
        </div>
        <div class="col-md-3">
          {{ chartbuster.loudness }}
        </div>
     </div>
      </div>
      </div>
      </div>
      </div>
    </div>
  </div>
</template>
<script>
 
import ChartbustersService from '@/api-services/chartbusters.service';

export default {
  name: 'ChartbusterDetails',
  data () {
    return {
      chartbuster: {}
    }
  },
  created() {
    ChartbustersService.get(this.$router.currentRoute.params.id).then((response) => {
      this.chartbuster = response.data;
    });
  }
}
</script>
