const path = require('path');
const fs = require('fs');

function getEntries(srcPath) {
  const files = fs.readdirSync(srcPath);
  const entries = {};

  files.forEach((file) => {
    const filePath = path.resolve(srcPath, file);
    const stats = fs.statSync(filePath);

    if (stats.isDirectory()) {
      Object.assign(entries, getEntries(filePath));
    } else if (file.endsWith('.ts') || file.endsWith('.tsx')) {
      const name = path.relative(srcPath, filePath).replace(/\.(ts|tsx)$/, '');
      entries[name] = filePath;
    }
  });

  return entries;
}

module.exports = {
  entry: getEntries('./src'), // Get all TypeScript files in src directory
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
    path: path.resolve(__dirname, '../wwwroot/js'),
  }
};
