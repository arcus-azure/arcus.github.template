const lightCodeTheme = require('prism-react-renderer/themes/github');
const darkCodeTheme = require('prism-react-renderer/themes/dracula');

/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
  title: 'Arcus - {component}',
  url: 'https://{component}.arcus-azure.net/',
  baseUrl: '/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/arcus.png',
  organizationName: 'arcus-azure', // Usually your GitHub org/user name.
  projectName: 'Arcus - {component}', // Usually your repo name.
  themeConfig: {
    image: 'img/arcus.jpg',
    navbar: {
      title: '{component}',
      logo: {
        alt: 'Arcus',
        src: 'img/arcus.png',
        srcDark: 'img/arcus.png'
      },
      items: [
        {
          type: 'docsVersionDropdown',
          position: 'right',
          dropdownActiveClassDisabled: true,
        },
        {
          type: 'search',
          position: 'right',
        },
        {
          href: 'https://github.com/arcus-azure/arcus.{component}',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Community',
          items: [
            {
              label: 'Arcus Azure Github',
              href: 'https://github.com/arcus-azure',
            },
          ],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()}, Arcus - {component} maintained by arcus-azure`,
    },
    prism: {
      theme: lightCodeTheme,
      darkTheme: darkCodeTheme,
      additionalLanguages: ['csharp', 'powershell'],
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          routeBasePath: "/",
          path: 'preview',
          sidebarCollapsible: false,
          // Please change this to your repo.
          editUrl:
            'https://github.com/arcus-azure/arcus.{component}/edit/master/docs',
          includeCurrentVersion:process.env.CONTEXT !== 'production',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
