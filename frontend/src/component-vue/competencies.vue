<template>
	<div v-bem>
		<section v-bem.list v-if="competencies.length" v-for="item in competencies">
			<article v-bem.item>
				<div v-bem.bar>
					<div v-bem.level v-bind:style="{width: item.level * 100 + '%' }"></div>
				</div>
				{{ item.competency.name }}
			</article>
		</section>
	</div>
</template>

<script>
	import axios from 'axios';
	export default {
		name: 'competencies',
		data() {
			return {
				competencies: [],
			};
		},
		mounted() {
			axios
				.get('http://127.0.0.1:8080/alternatives.json')
				.then(response => {
					this.competencies = response.data.employee.competencies;
				});
		}
	};
</script>