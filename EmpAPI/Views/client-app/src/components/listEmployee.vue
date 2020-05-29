<template>
  <div class="listEmp">
    <div>
      <h1>Danh sách nhân viên</h1>
    </div>
    <div class = 'toolbar'>
      <button type="button" class="btn btn-primary" v-on:click="isShowingAdd()">
        <i class="icon-add"></i>Thêm mới    
      </button>
    </div>
    <div class="overflow-auto">
      <table class="table">
        <thead class="thead-dark">
          <tr>
            <th scope="row">STT</th>
            <th scope="col">Mã nhân viên</th>
            <th scope="col">Họ và tên</th>
            <th scope="col">Tuổi</th>
            <th scope="col">Giới tính</th>
            <th scope="col">Điện thoại</th>
            <th scope="col">Quê quán</th>
            <th scope="col">Hành động</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item,index) in listEmployees " v-bind:key="index">
            <th scope="row">{{index+1}}</th>
            <td>{{item.employeeCode}}</td>
            <td>{{item.employeeName}}</td>
            <td>{{item.age}}</td>
            <td>{{item.gender}}</td>
            <td>{{item.phone}}</td>
            <td>{{item.address}}</td>
            <td>
              <button type="button" class="btn btn-warning" v-on:click="isShowingEdit(item)">Sửa</button>
              <button type="button" class="btn btn-danger" v-on:click="isShowingDelete(item.employeeId)">Xóa</button>
            </td>
          </tr>
        </tbody>
      </table>
      <div>
         <modalAdd @getEmp="addEmployee"></modalAdd>
      </div>
      <div>
        <modalDelete></modalDelete>
      </div>
      <div>
        <modalEdit @getEmpEdited="editEmployee" :employee="employee"></modalEdit>
      </div>
    </div>
  </div>
</template>
<script>
import axios from 'axios';
import modalAdd from './modalAdd'
import modalDelete from './modalDelete'
import modalEdit from './modalEdit'
export default {
  name: 'listEmp',
  components:{
    modalAdd,
    modalDelete,
    modalEdit
  },
  data () {
    return {
      interval: '',
      // empCode : '',
      // empName : '',
      // empAge : '',
      // empGender : '',
      // empPhone : '',
      // empAddress : '',
      listEmployees:[],
      employee: {},
      errors: []
    }
  },
  methods:{
    isShowingAdd(){
        $('#addEmp').modal('toggle');
    },
    isShowingDelete(id){
        $('#deleteEmp').modal('toggle');
    },

    isShowingEdit(employee){
        this.employee = JSON.parse(JSON.stringify(employee));
        $('#editEmp').modal('toggle');
    },
    /* 
      Hàm thêm fresher
      Created by : Phong
      Created date: 22/5/2020
    */
    addEmployee(emp){
      axios.post('https://localhost:44344/api/Employees/', emp)
    },

    editEmployee(emp){
      axios.put('https://localhost:44344/api/Employees/' + emp.employeeId, emp)
    },
    /* 
      Hàm xóa fresher
      Created by : Phong
      Created date: 22/5/2020
    */
    deleteEmployee(id){
      axios.delete('https://localhost:44344/api/Employees/' + id)
    }
  },
  async created(){
    var res = await axios.get(`https://localhost:44344/api/Employees`);
    this.listEmployees = res.data;
    // Phần này sau sẽ phục vụ cho việc load data từ server 
    // this.listEmployees = [
    //     {id: 'NV0001', name: 'Nguyễn Ngọc Phong', age: '20', gender:'Nam', phone: '0382083624', country: 'Bắc Ninh'},
    //     {id: 'NV0002', name: 'Cao Văn Cường', age: '20', gender:'Nam', phone: '03223232', country: 'Thanh Hóa'},
    //     {id: 'NV0003', name: 'Trần Viết Phi', age: '20', gender:'Nam', phone: '012345678', country: 'Hà Tĩnh'},
    //     {id: 'NV0004', name: 'Nguyễn Tuấn Ngọc', age: '20', gender:'Nam', phone: '012332324', country: 'Bắc Giang'},
    //     {id: 'NV0005', name: 'Đông Đoan Trang', age: '23', gender:'Nam', phone: '32323232', country: 'Sơn La'},
    //   ]
  },
  beforeMount() {
  },
  mounted(){
  },
  beforeUpdate(){
  },
  async updated(){
    // var res = await axios.get(`https://localhost:44344/api/Employees`);
    // this.listEmployees = res.data;
  },
  watch:{
    //khi có sự thay đổi dữ liệu trên component
    listEmployees(newVal, oldVal){}
  },
  beforeDestroy(){
  },
  destroyed() { 
  },    
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
a {
  color: #42B983;
}
.toolbar{
  width: 100%;
  height: 40px;
  background-color: #F0F1FC;
  display: flex;
  margin-bottom: 5px;
}
.toolbar button{
  position: absolute;
  right: 100px;
  margin: 5px 10px 0px 0px;
  background-color: #01A971;
  border: none;
  display: flex;
  border-radius: 5px;
  width: auto;
  color: #fff;
}
.toolbar button:hover{
  background-color: #42B983;
  cursor: pointer;
}
.icon-add{
  /* background-image: url("../assets/add.png"); */
  background-repeat: no-repeat;
  display: block;
  width: 25px;
  height: 25px;
  padding-right: 5px;
}
.icon-delete{
  /* background-image: url("../assets/del.png"); */
  background-repeat: no-repeat;
  display: block;
  width: 25px;
  height: 25px;
  padding-right: 5px;
  background-size: 25px;
}
</style>