
/// <binding BeforeBuild='less' />

var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');
var plumber = require('gulp-plumber');

var lessConfig = {
  //Include all less files
  src: ['./Style/**/*.less'] //, '!app/**/*.min.js']
}



gulp.task('less', function () {
  return gulp.src(lessConfig.src)
  .pipe(plumber())
    .pipe(less({
      paths: [path.join(__dirname, 'less', 'includes')]
    }))
    .pipe(gulp.dest('./Style/'));
});


// watch file and less 
gulp.task('watch', function () {
  return gulp.watch(lessConfig.src, ['less']);
});

//Set a default tasks
gulp.task('default', ['less'], function () { });