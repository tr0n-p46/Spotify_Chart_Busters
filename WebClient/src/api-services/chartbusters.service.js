import Axios from 'axios'

const RESOURCE_NAME = '/chartbusters'

export default {
  getAll () {
    return Axios.get(RESOURCE_NAME + '?OrderBy=&OrderByAsc=true&Search=&Start=0&Count=50')
  },

  get (id) {
    return Axios.get(RESOURCE_NAME + '/' + id)
  }
}
