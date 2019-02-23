<template>
  <tr>
    <td>{{ chartbuster.rank }}</td>
    <td>{{ chartbuster.name }}</td>
    <td>{{ chartbuster.artists }}</td>
    <td>
      <b-button variant="default"
      @click="onDetailsClick">Details</b-button>
    </td>
  </tr>
</template>
<script>
export default {
  name: 'chartbuster',
  props: [ 'chartbuster' ],
  methods: {
    onDetailsClick () {
      this.$emit('details', this.chartbuster.id)
    }
  }
}
</script>
