'use strict';

var gulp = require('gulp'),
    concat = require('gulp-concat');

gulp.task('concatScripts', function() {
    return gulp.src([
        './scripts/angular/angular.min.js',
        './scripts/angular/angular-route.min.js',
        './earlybirds.module.js',
        './earlybirds.routes.js',
        './earlybirds.filters.js',
        './account/authentication.service.js',
        './account/loginForm.controller.js',
        './main.controller.js',
        './app/**/*.js'
        ])
        .pipe(concat('app.js'))
        .pipe(gulp.dest('dist'));
});

gulp.task('default', ['concatScripts']);