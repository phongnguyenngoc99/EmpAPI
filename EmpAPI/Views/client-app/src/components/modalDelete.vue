<template>
    <div class="modal" tabindex="-1" role="dialog" id="deleteEmp">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Thêm mới nhân viên</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div>
                    Hello 
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" v-on:click="getModalData()">Lưu</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
            </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name : 'modal',
    data() {
        return {
            listEmployees:[]
        }
    },
    methods:{
    }
}
</script>
<style scoped>
    .modal-dialog{
        top: 100px;
    }
</style>