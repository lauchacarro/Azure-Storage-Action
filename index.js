const exec = require('@actions/exec');
const core = require('@actions/core');

const main = async () => {
    const connectionString = core.getInput('connection-string');
    const folder = core.getInput('folder');
    const containerName = core.getInput('blob-container-name');
    const accessPolicy = core.getInput('public-access-policy');
    const enableStaticWebSite = core.getInput('enabled-static-website');

    let args = ['run', '-c', 'Release', '--project', __dirname + '/src/AzureStorageAction.csproj', '--'];

    if (connectionString) {
        args.push('-c')
        args.push(connectionString)
    }

    if (folder) {
        args.push('-f')
        args.push(folder)
    }

    if (containerName) {
        args.push('-n')
        args.push(containerName)
    }

    if (accessPolicy) {
        args.push('-a')
        args.push(accessPolicy)
    }

    if (enableStaticWebSite) {
        args.push('-s')
        args.push(enableStaticWebSite)
    }

    await exec.exec('dotnet', args);
};

main().catch(err => {
    console.error(err);
    console.error(err.stack);
    process.exit(-1);
})