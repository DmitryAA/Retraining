import Vue from 'vue';
import vuex from 'vuex';
import vBem from 'v-bem';

import store from './store';
import alternatives from 'component-vue/alternatives';


Vue.use(vuex);
Vue.use(vBem, {blockPrefix: 'b-', modSeparator: '--'});

const Store = new vuex.Store(store);

let app = new Vue({
	components: {alternatives},
	store: Store
});

document.addEventListener("DOMContentLoaded", function() {
	app.$mount('#alternatives');
});


new Vue({
	ell: '#alternatives',
});