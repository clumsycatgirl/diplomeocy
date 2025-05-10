const path = require('path');
const fs = require('fs');
function getEntries(srcPath, relativePath = '.') {
    const files = fs.readdirSync(srcPath);
    const entries = {};
    files.forEach((file) => {
        const filePath = path.resolve(srcPath, file);
        const relativeFilePath = path.relative(srcPath, filePath);
        const stats = fs.statSync(filePath);
        if (stats.isDirectory()) {
            Object.assign(entries, getEntries(filePath, path.join(relativePath, file)));
        }
        else if (file.endsWith('.ts') || file.endsWith('.tsx')) {
            const name = path.join(relativePath, file).replace(/\.(ts|tsx)$/, '');
            entries[name] = filePath;
        }
    });
    return entries;
}
module.exports = {
    entry: getEntries('./src'),
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, '../DiplomeocyWeb/wwwroot/js'),
    },
    optimization: {
        minimize: false,
    },
};
