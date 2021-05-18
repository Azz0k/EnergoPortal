'use strict';

const webpack = require('webpack');
const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const bundleFolder = './wwwroot/assets/';
const srcFolder = './ClientApp/'
const WebpackMd5Hash = require('webpack-md5-hash');

module.exports = {
    mode: 'development',
    entry: [
        srcFolder + 'index.jsx' 
    ], 
    devtool: 'source-map',
    output: {
        filename: 'bundle.js',
        publicPath: 'assets/',
        path: path.resolve(__dirname, bundleFolder)
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: 'style.css',
        }),

    ],
    module: {
        rules: [
            {
                test: /\.jsx$/,
                exclude: /(node_modules)/,
                loader: 'babel-loader',
                options: {
                    presets: ['@babel/preset-env', '@babel/preset-react']
                },
            },
            {
                test: /\.css$/i,
                use: ['style-loader',
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                ],
            },
        ]
    },
    
};