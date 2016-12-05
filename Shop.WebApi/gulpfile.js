/// <binding />
var gulp = require('gulp'),
    gp_clean = require('gulp-clean'),
    gp_concat = require('gulp-concat'),
    gp_less = require('gulp-less'),
    gp_sourcemaps = require('gulp-sourcemaps'),
    gp_typescript = require('gulp-typescript'),
    gp_uglify = require('gulp-uglify'),
    gp_util = require('gulp-util');

var $ = require('gulp-load-plugins')({ lazy: true });
var webpack = require('webpack');
var gutil = require('gutil');
var config = require('./webpack.dev.js');
var pump = require('pump');
var minifier = require('gulp-uglify/minifier');

/// Define paths
var srcPaths = {
    app: ['angular2App/app/main.ts', 'angular2App/app/**/*.ts'],
    js: [
        'angular2App/js/**/*.js',
        'node_modules/core-js/client/shim.min.js',
        'node_modules/zone.js/dist/zone.js',
        'node_modules/reflect-metadata/Reflect.js',
        'node_modules/systemjs/dist/system.src.js',
        'node_modules/typescript/lib/typescript.js',
        'node_modules/ng2-bootstrap/bundles/ng2-bootstrap.min.js',
        'node_modules/moment/moment.js'
    ],
    js_angular: [
        'node_modules/@angular/**'
    ],
    js_rxjs: [
        'node_modules/rxjs/**'
    ]
};

var destPaths = {
    app: 'wwwroot/app/',
    js: 'wwwroot/js/',
    js_angular: 'wwwroot/js/@angular/',
    js_rxjs: 'wwwroot/js/rxjs/'
};

// Compile, minify and create sourcemaps all TypeScript files 
// and place them to wwwroot/app, together with their js.map files.
gulp.task('app', ['app_clean'], function (cb) {
    pump([
        gulp.src(srcPaths.app),
        /*
        Since gp_"uglify does not support angular classes, its using webpack instead
        gp_sourcemaps.init(),
        gp_typescript(require('./tsconfig.json').compilerOptions),
        gp_uglify({mangle:false}).on('error', gutil.log),
        gp_sourcemaps.write('/'),*/
        gulp.dest(destPaths.app)
    ],
    cb
    );
});

// Delete wwwroot/app contents
gulp.task('app_clean', function () {
    return gulp.src(destPaths.app + "*", { read: false })
    .pipe(gp_clean({ force: true }));
});

gulp.task('webpack', function (done) {
    webpack(config).run(onBuild(done));
});

function onBuild(done) {
    return function (err, stats) {
        if (err) {
            gutil.log('Error', err);
            if (done) {
                done();
            }
        }
        else {
            Object.keys(stats.compilation.assets).forEach(function (key) {
                gutil.log('(+)Webpack:' + key);
            });
            gutil.log('(-)Webpack: ' + stats.compilation.name);
            if (done) {
                done();
            }
        }
    };
}

// Watch specified files and define what to do upon file changes
gulp.task('watch', function () {
    //gulp.watch([srcPaths.app, srcPaths.js], ['app', 'js']);
    gulp.watch([srcPaths.app, srcPaths.js], ['app', 'webpack']);
});

// Define the default task so it will launch all other tasks
//gulp.task('default', ['app', 'js', 'watch']);  
gulp.task('default', ['webpack', 'app', 'watch']);