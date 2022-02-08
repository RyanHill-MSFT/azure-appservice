<?php
#index.php
require_once('shared/PageTemplate.php');
# trick to execute 1st time, but not 2nd so you don't have an inf loop
if (!isset($TPL)) {
    $TPL = new PageTemplate();
    $TPL->PageTitle = "My Title";
    $TPL->ContentBody = __FILE__;
    include "shared/_layout.php";
    exit;
}
?>
<p><?php echo "Hello!"; ?></p>