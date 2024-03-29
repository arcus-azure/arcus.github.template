# Website

This website is built using [Docusaurus 2](https://docusaurus.io/), a modern static website generator.

## Prerequisites
This documentation assumes that you run all scripts within the docs folder.

```console
cd docs
```


## Installation

```console
npm install
```

## Local Development

```console
npm start
```

This command starts a local development server and opens up a browser window. Most changes are reflected live without having to restart the server.

## Configuration

Replace all occurences of `{component}` within the `package.json` and `docusaurus.config.js`

## Static assets
Every website needs assets: images, stylesheets, favicons etc. In such cases, you can add them to the directory `./static/media`.

Every file you put into the `./static` directory will be copied into the root of the generated build folder with the directory hierarchy preserved. E.g. if you add a file named `sun.jpg` to the `./static` folder, it will be copied to `build/sun.jpg`.

This means:

- `./static/media/someImage.jpg` needs to be referenced as `/media/someImage.jpg`
- `./static/media/someDirectory/someAsset.svg` needs to be referenced as `/media/someDirectory/someAsset.svg`

## Sidebar
By default, the sidebar slice will be generated in alphabetical order (using files and folders names).

If the generated sidebar does not look good, you can assign additional metadatas to docs and categories.

### Docs / .md files
```markdown
---
sidebar_label: Easy
sidebar_position: 2
---

# Easy Tutorial

This is the easy tutorial!
```

### Categories / Directories

Add a `_category_.json` or `_category_.yml` file in the appropriate folder:

```yaml
label: 'Tutorial'
position: 2.5 # float position is supported
collapsible: true # make the category collapsible
collapsed: false # keep the category open by default
```

More info: https://docusaurus.io/docs/sidebar#autogenerated-sidebar-metadatas

## Versioning
https://docusaurus.io/docs/versioning

You can use the version script to create a new documentation version based on the latest content in the `./preview` directory. That specific set of documentation will then be preserved and accessible even as the documentation in the docs directory changes moving forward.

### Tagging a new version

1. First, make sure your content in the `./preview` directory is ready to be frozen as a version. A version always should be based from master.
2. Enter a new version number: 
   
`npm run docusaurus docs:version v1.1.0`

---
When tagging a new version, the document versioning mechanism will:

- Copy the full `./preview` folder contents into a new `versioned_docs/version-<version>/` folder.
- Create a versioned sidebars file based from your current sidebar configuration (if it exists) - saved as `versioned_sidebars/version-<version>-sidebars.json`.
- Append the new version number to `versions.json`.

## Syntax higlighting

To have syntax highlighting within the codeblocks you have to use one of the prism supported languages:
https://github.com/FormidableLabs/prism-react-renderer/blob/master/src/vendor/prism/includeLangs.js

---

To add syntax highlighting for any of the other Prism supported languages, define it in an array of additional languages within the `docusaurus.config.js` file as seen here:
https://docusaurus.io/docs/markdown-features/code-blocks#supported-languages

## Deploying to Netlify

https://docusaurus.io/docs/deployment#deploying-to-netlify

Replace the `YOUR_NETLIFY_SITE_ID` inside the repo root `./netlify.toml` file with your Netlify site ID.
