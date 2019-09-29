<template>
	<div v-bem>
		<div v-bem.overlay v-if="courses.length > 0" @click="close">
			<div v-bem.popup>
				<h2>Рекомендуемые курсы обучения</h2>
				<div v-bem.middle>
					<div v-bem.row>
						<div v-bem.course v-for="course in courses">
							<img src="https://via.placeholder.com/350x172?text=No photo" width="350" height="172"><br>
							<p>{{ course.name }}</p>
							<p>Продолжительность {{ course.price }} часов</p>
						</div>
					</div>
				</div>
			</div>
		</div>
		<section  v-if="recommendations.length">
			<div v-bem.row>
				<div v-bem.info>
					<h2>Траектория развития</h2>
					<p>Рекомендуемые вакансии</p>
				</div>
			</div>
			<div v-bem.row>
				<article v-bem.item v-for="item in recommendations" @click="show(item.position.id)">
					{{ item.position.name }}<br>
				</article>
			</div>
		</section>
	</div>
</template>

<script>
	import axios from 'axios';
	export default {
		name: 'projects',
		methods: {
			'close': function() {
				this.courses = [];
			},
			'show': function (id) {
				this.courses = this.recommendations.find(item => item.position.id === id).courses;
			}
		},
		data() {
			return {
				recommendations: [],
				courses: [],
			};
		},
		mounted() {
			axios
				.get('http://127.0.0.1:8080/alternatives.json')
				.then(response => {
					this.recommendations = response.data.recommendations;
				});
		}
	};
</script>