import Vue from 'vue';
import vBem from 'v-bem';

import competencies from 'component-vue/competencies';

Vue.use(vBem, {blockPrefix: 'b-', modSeparator: '--'});

let app = new Vue({
	components: {competencies},
});

document.addEventListener("DOMContentLoaded", function() {
	app.$mount('#competencies');
});


new Vue({
	ell: '#competencies',
});